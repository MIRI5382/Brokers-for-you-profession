using Bl.Bo;
using Bo;
using Dal;
using Dal.Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlImplemetiaon
{
    public class ServerBCours
    {
        private DalManager _dManager;
        private SevicTime _sTime;

        public ServerBCours(DalManager dM, SevicTime sevicTime) 
        { 
            _dManager = dM; 
            _sTime=sevicTime;
        }
        public BCours ConvertToBl(Course c)
        {
            BCours bc=new BCours();
            bc.CodeSubject = c.CodeSubject;
            bc.CodeCourse = c.CodeCourse;   
            bc.DateOfCourseEnd = c.DateOfCourseEnd;
            bc.DateOfCourseStart= c.DateOfCourseStart;
            bc.NameOfCourse = c.NameOfCourse;
            bc.Times = _sTime.ConvertTimeListToBl(c.Times.ToList());
            bc.NumQuality = c.NumQuality;
            bc.SortCourse = c.SortCourse;
            return bc;
        }
        public Course ConvertToDal(BCours c)
        {
            Course bc = new Course();
            bc.CodeSubject = c.CodeSubject;
         if(c.CodeCourse!=null)  
                bc.CodeCourse = (int)(c.CodeCourse) ;
         else
                bc.CodeCourse =0;
            bc.DateOfCourseEnd = c.DateOfCourseEnd;
            bc.DateOfCourseStart = c.DateOfCourseStart;
            bc.NameOfCourse = c.NameOfCourse;
            bc.Times = _sTime.ConvertTimeListToDal(c.Times.ToList());
            bc.NumQuality = c.NumQuality;
            bc.SortCourse = c.SortCourse;
            return bc;
        }
       

        private object mapAll;
        public List<BCours> ListToBl(List<Course> list)
        {
            List<BCours> lst = new List<BCours>();
            list.ForEach(x => lst.Add(ConvertToBl(x)));
            return lst;
        }      
     
        public int Post(BCours courses)=>       
            _dManager.SCourses.Post(ConvertToDal(courses));
        
    }
}
