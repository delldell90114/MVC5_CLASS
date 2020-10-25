using System;
using System.Linq;
using System.Collections.Generic;

namespace _20201018_MVC5_CLASS_01.Models
{
	public  class CourseRepository : EFRepository<Course>, ICourseRepository
	{

	}

	public  interface ICourseRepository : IRepository<Course>
	{

	}
}