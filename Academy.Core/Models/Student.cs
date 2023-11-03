using System;
using Academy.Core.Enums;
using Academy.Core.Models.BaseModels;

namespace Academy.Core.Models
{
	public class Student:BaseModel
	{
		static int _id;
		public string FullName { get; set; }
		public string Group { get; set; }
		public int Average { get; set; }
		public Education Education { get; set; }

		public Student(string fullname,string group,int average,Education education)
		{
			_id++;
			FullName = fullname;
			Group = group;
			Average = average;
			Education = education;
            Id = $"{Education.ToString()[0]}-{_id}";

        }

    }
}

