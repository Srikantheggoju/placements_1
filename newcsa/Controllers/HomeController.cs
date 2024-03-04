using System.Data.Common;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Mvc;
using newcsa.Models;

namespace newcsa.Controllers;


public class HomeController : Controller
{
   

public ActionResult Index(){
    return View();
}
    CsaContext cd = new CsaContext();

    //admin enters student details
    public ActionResult enter_details(){
        return View();
    }

    [HttpPost]
    public ActionResult enter_details(Student st){
        var res = (from t in cd.Students where t.StdId==st.StdId select new {idd=t.StdId}).Count();
        if(res!=0){
            ViewData["result"]="sorry, student already exist";
            return View();
        }
        cd.Students.Add(st);
        int i = cd.SaveChanges();
       Meassage mm = new Meassage();
        if(i>0){
            //ViewData["x"]="data entered succesfully";
            if(35>st.Marks){
                ViewData["result"]="you are failed";
                 mm.MsgData="you are failed";
                mm.StdId=st.StdId;
                cd.Meassages.Add(mm);
                cd.SaveChanges();
                
                return RedirectToAction("your_message");
            }

            else if((35<= st.Marks)&& (st.Marks<=60)){
                ViewData["result"]="you are average";
               mm.MsgData="you are average";
                mm.StdId=st.StdId;
                mm.Std=null;
                cd.Meassages.Add(mm);
                cd.SaveChanges();
                return RedirectToAction("your_message");
            }

            else if((60<= st.Marks)&& (st.Marks<=80)){
                ViewData["result"]="you are good";
                mm.MsgData="you are good";
                mm.StdId=st.StdId;
                cd.Meassages.Add(mm);
                cd.SaveChanges();

                return RedirectToAction("your_message");
            }

            else{
                ViewData["result"]="you are very good";
                mm.MsgData="you are very good";
                mm.StdId=st.StdId;
                cd.Meassages.Add(mm);
                cd.SaveChanges();
                return RedirectToAction("your_message");
            }

           
        }

        else{
            ViewData["result"]="data not entered";
            return View();
        }
    }
    public ActionResult adminlogin(){
        return View();
    }

    [HttpPost]
    public ActionResult adminlogin(string uname, string pwd){
        ViewData["err"]="login failed";
        if(uname=="admin" && pwd=="india"){
            
        return RedirectToAction("enter_details");
        }
        else return View();
    }


    //student login part
    public ActionResult student_login(){
        return View();
    }
    [HttpPost]
    public ActionResult student_login(Student st){
        var res = (from t in cd.Students where t.Password==st.Password &&
         t.StdId==st.StdId select t).Count();
        
        if (res>0) {
       TempData["id"]=st.StdId;
        return RedirectToAction("your_message");
        }
      
        else{
            ViewData["result"]="please enter valid details";
            return View();
        }
    }

    public ActionResult your_message(){
        
        List<string> arr = new List<string>();
        var xx = from t in cd.Meassages select new {data1=t.StdId, data2=t.MsgData};
        foreach (var item in xx)
        {
            if(Convert.ToInt32(TempData["id"])==item.data1)
            {
                arr.Add(item.data2);
                return View(arr);
            }
        }
      return View();
        
       
}
}
