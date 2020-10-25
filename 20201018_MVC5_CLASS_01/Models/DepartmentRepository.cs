using System;
using System.Linq;
using System.Collections.Generic;

namespace _20201018_MVC5_CLASS_01.Models
{
	public  class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
	{
        public override IQueryable<Department> All()
        {
            return base.All().Where(p => p.IsDeleted == false);
        }
        public override void Delete(Department entity)
        {
            // ** �i�H���L���� **
            this.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;
            entity.IsDeleted = true;
        }
        public Department GetDepartment(int id)
        {
            return base.All().FirstOrDefault(p => p.DepartmentID == id);
        }
    }

	public  interface IDepartmentRepository : IRepository<Department>
	{

	}

	
}