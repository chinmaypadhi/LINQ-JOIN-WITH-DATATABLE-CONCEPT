using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ConsoleApp7
{
    public class employee
    {
        public int id { get; set; }
        public String name { get; set; }
        public string city { get; set; }
        public string dob { get; set; }


    }


    public class subject
    {
        public int Subid { get; set; }
        public String subname { get; set; }
        public String subdes { get; set; }
    }

    public class tagingTab
    {
        public int id { get; set; }
        public int Empid { get; set; }
        public int subid { get; set; }
    }




    class Program
    {
        static void Main(string[] args)
        {
            List<subject> stdList = new List<subject>() { new subject { Subid=1,subdes="jfknvjbd",subname="hindi"},
            new subject { Subid=2,subdes="jfknvjbd",subname="eng"}
            ,new subject { Subid=3,subdes="jfknvjbd",subname="odia"}
            };


            List<employee> obj = new List<employee>() { new employee { id = 1, name = "chinmay", city = "bhadrak", dob = "24" },


             new employee { id = 2, name = "bibek", city="kendrapada",dob="24" },
              new employee { id = 3, name = "mantu", city="bhadrak",dob="24" }

            };



            DataTable dtMember = new DataTable();

            dtMember.Columns.Add("id");
            dtMember.Columns.Add("name");
            dtMember.Columns.Add("city");
            dtMember.Columns.Add("dob");


            List<employee> emplist = new List<employee>();
            foreach (var items in obj)
            {
                DataRow dr = dtMember.NewRow();
                dr["id"] = items.id;
                dr["name"] = items.name;
                dr["city"] = items.city;
                dr["dob"] = items.dob;
                dtMember.Rows.Add(dr);
            }


            if (dtMember.Rows.Count > 0)
            {
                for (int i = 0; i < dtMember.Rows.Count; i++)
                {
                    employee objemp = new employee() {id=Convert.ToInt32(dtMember.Rows[i]["id"]),name= (dtMember.Rows[i]["name"]).ToString(),city= (dtMember.Rows[i]["city"]).ToString(),dob= (dtMember.Rows[i]["dob"]).ToString() };
                    emplist.Add(objemp);
                }

            }





            //if (dtMember.Rows.Count>0)
            //{
            //    for(int i=0;i< dtMember.Rows.Count;i++)
            //    {
            //           Console.WriteLine("id:{0},name:{1},city:{2},dob:{3}", dtMember.Rows[i]["id"].ToString(), dtMember.Rows[i]["name"].ToString(), dtMember.Rows[i]["city"].ToString(), dtMember.Rows[i]["dob"].ToString());

            //    }

            //}

            List<tagingTab> tagList = new List<tagingTab>() { new tagingTab { id=1,Empid=1,subid=1},
            new tagingTab { id=2,Empid=1,subid=2},
             new tagingTab { id=3,Empid=2,subid=3},
              new tagingTab { id=4,Empid=3,subid=1},
              new tagingTab { id=5,Empid=3,subid=3}
            };


            var qs = (from k in emplist
                      join l in tagList on k.id equals l.Empid
                      join m in stdList on l.subid equals m.Subid
                      select new
                      {
                          employeeName=k.name,
                          employeeCity=k.city,
                          subjectDes=m.subdes,
                          subName=m.subname,                       
                      }
                    ).ToList();
           foreach(var t in qs)
            {
                Console.WriteLine("employee Name:{0},Employee City:{1},Subject Description:{2},Subject Name:{3}",t.employeeName,t.employeeCity,t.subjectDes,t.subName);

            }

            Console.Read();
        }
    }
}
