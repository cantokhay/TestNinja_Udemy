namespace TestNinja.Mocking
{
    public interface IEmployeeData
    {
        void DeleteEmployee(int id);
    }

    public class EmployeeData : IEmployeeData
    {
        private EmployeeContext _db;

        public EmployeeData()
        {
            _db = new EmployeeContext();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);

            if (employee == null) return;

            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }

}
