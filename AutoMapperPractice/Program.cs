using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoMapperPractice.Mapper;

namespace AutoMapperPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Student student = new Student();
            student.Name = "Andy";
            student.Id = 001;
            student.phoneNumber = 01234567;

            // 這邊這樣寫會寫死，沒辦法用ForMember去做型別對應
            // 再現有套件下加以封裝，可以更簡單的達到轉換的目的，讓下面的程式碼可以一行執行
            // 不用思考到formember
            User result = MyMapper.Map<User, Student>(student);//Mapper.Map<TDestination, TSource>(source);
            User dtoModel = MyMapper.Map<User, Student>(student, map =>
            {
                map.ForMember(dest => dest.idNumber, opt => opt.MapFrom(src => src.Id));
                map.ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.Name));
                map.ForMember(dest => dest.userPhoneNumber, opt => opt.MapFrom(src => src.phoneNumber));
            });
            Console.WriteLine(result);
            Console.WriteLine(dtoModel);
        }
    }
}
