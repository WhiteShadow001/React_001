using Npgsql;
using SDCApiLearning.Data;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace SDCApiLearning.Repo
{
    public class StudentContext
    {
        public List<StudentData> GetStudentList()
        {
            //DB Connect
            //Query
            StudentData s1 = new StudentData
            {
                name = "Ram",
                subject_id = 0,
            };

            StudentData s2 = new StudentData
            {
                name = "Shyam",
                subject_id = 0,
            };

            List<StudentData> list = new List<StudentData>();
            list.Add(s1);
            list.Add(s2);

            return list;
        }

        public List<StudentData> GetStudentDatasFromDB(int id)
        {

            List<StudentData> Data = new List<StudentData>();


            using (var connection = CreateConnection())
            {
                if (id == 0)
                    Data = connection.Query<StudentData>("select * from tbl_student").ToList();
                else
                    Data = connection.Query<StudentData>("select * from tbl_student where id=@something", new
                    {
                        something = id
                    }).ToList();
            }

            return Data;
        }

        public void InsertIntoStudent(StudentData data)
        {
            using (var connection = CreateConnection())
            {

                connection.Execute(@"
INSERT INTO public.tbl_student(
	name, sub_id, gen_id)
	VALUES (@name, @subject_id, @gender_id);
", data);
            }
        }

        public void UpdateStudent(StudentData data)
        {
            using (var connection = CreateConnection())
            {
                
                connection.Execute(@"
UPDATE public.tbl_student
	SET  name=@name
	WHERE id=@id;
", data);
            }
        }

        public List<GenderList> GetGenderFromDB()
        {

            List<GenderList> Data = new List<GenderList>();


            using (var connection = CreateConnection())
            {
               
                    Data = connection.Query<GenderList>("select * from tbl_gender").ToList();
            }

            return Data;

        }


        public List<GenderList> GetSubjectFromDB()
        {

            List<GenderList> Data = new List<GenderList>();


            using (var connection = CreateConnection())
            {

                Data = connection.Query<GenderList>("select * from tbl_subject").ToList();
            }

            return Data;

        }

        public NpgsqlConnection CreateConnection()
        {
            var conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=sdc;User Id=postgres;Password=Jeshan123;");
            conn.Open();
            return conn;
        }
    }
}