using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWeb.Models;


namespace FirstWeb.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly AppDBContext appDBContext;

        public StudentRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Add(Student student)
        {
            appDBContext.Students.Add(student);
            appDBContext.SaveChanges();
            return student;
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student Delete(int id)
        {
            var student = appDBContext.Students.Find(id);
            if (student != null)
            {
                appDBContext.Students.Remove(student);
                appDBContext.SaveChanges();
            }
            return student;
        }

        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Update(Student student)
        {
            var oldStudent = appDBContext.Students.Attach(student);
            oldStudent.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDBContext.SaveChanges();
            return student;
        }

        /// <summary>
        /// 获取所有学生数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetAllStudents()
        {
            return appDBContext.Students;
        }

        /// <summary>
        /// 获取单个学生的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetStudent(int id)
        {
            return appDBContext.Students.Find(id);
        }

        

    }
}
