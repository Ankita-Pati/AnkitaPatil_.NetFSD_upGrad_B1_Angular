using EFCoreAssignment2.Models;

namespace EFCoreAssignment2.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course GetById(int id);
        void Add(Course course);
        void Update(Course course);
        void Delete(int id);
    }
}
