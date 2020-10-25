using System;
using System.Linq;
using System.Collections.Generic;

namespace _20201018_MVC5_CLASS_01.Models
{
	public  class OfficeAssignmentRepository : EFRepository<OfficeAssignment>, IOfficeAssignmentRepository
	{

	}

	public  interface IOfficeAssignmentRepository : IRepository<OfficeAssignment>
	{

	}
}