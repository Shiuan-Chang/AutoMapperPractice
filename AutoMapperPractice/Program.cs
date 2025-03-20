using AutoMapper;
using System;
using System.Collections;
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
            //List<Student> students = new List<Student>
            //{
            //    new Student { Name = "Andy", Id = 1, phoneNumber = 1234567 },
            //    new Student { Name = "Betty", Id = 2, phoneNumber = 7654321 }
            //};

            //List<User> dtoModels = MyMapper.Map(students, (IMappingExpression<Student, User> map) =>
            //{
            //    map.ForMember(dest => dest.idNumber, opt => opt.MapFrom(src => src.Id)); // dest指的是目標物件
            //    map.ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.Name));
            //    map.ForMember(dest => dest.userPhoneNumber, opt => opt.MapFrom(src => src.phoneNumber));
            //});


            //List<string> list = new List<string>();
            //Type typeOfList = list.GetType();
            //可以透過IsArray來確認該類型是否為陣列: typeOfList.IsArray
            //如果不是array 而是其他物件容器 可以使用該方法來檢查: typeof(IEnumerable<>).IsAssignableFrom(typeOfList)

            //int[] numbers = { 7, 9 };
            //IEnumerable<int> nums = numbers;
            //var temp = numbers.GetType();// 檢查是否是Enumerable
            //bool isArray = temp.IsArray;
            //string typeName = temp.GetElementType().Name; // 只是要看是哪個名字的陣列:Int32
            //Array int_arr = Array.CreateInstance(temp.GetElementType(), nums.Count());// temp.GetElementType 根據type拿到對應屬性:數字, nums.Count() 數量

            //int index = 0;
            //foreach (int i in nums) {
            //    int_arr.SetValue(i, index++);
            //}


            List<int> numbers = new List<int> { 1, 2, 3 };

            var result = Mapper.MyMapper.Map<string, int>(numbers, map =>
            {
                map.ConvertUsing(src => src.ToString()); // 明確轉換成字串
            });

            Console.WriteLine(string.Join(", ", result)); // 正確輸出: "1, 2, 3"



            //List<int> numbers = new List<int> { 1, 2, 3 };

            //// 將數字轉換為字串
            //var result = Mapper.MyMapper.Map<string, int>(numbers);

            //Console.WriteLine(string.Join(", ", result));
            //Console.ReadKey();
            //IEnumerable<string> nums = list;
            //bool isCollection = typeof(IEnumerable).IsAssignableFrom(nums.GetType());//測試是否為一個collection

            //var temp = nums.GetType();

            //var genericType = temp.GetGenericTypeDefinition(); // List`1 => List<> 做轉換
            //var genericArguments = temp.GetGenericArguments(); // Int32

            //var listofStringType = genericType.MakeGenericType(typeof(int));  //List<string>
            //IList listofString = (IList)Activator.CreateInstance(listofStringType);

            //foreach (var item in nums) {
            //    var targetType = listofString.GetType().GenericTypeArguments.First();
            //    var value = Convert.ChangeType(item,targetType);
            //    listofString.Add(value);
            //}


        }
            

        //Student student = new Student();
        //student.Name = "Andy";
        //student.Id = 001;
        //student.phoneNumber = 01234567;

        //這邊這樣寫會寫死，沒辦法用ForMember去做型別對應
        //再現有套件下加以封裝，可以更簡單的達到轉換的目的，讓下面的程式碼可以一行執行
        //不用思考到formember
        //User result = MyMapper.Map<User, Student>(student);//Mapper.Map<TDestination, TSource>(source);
        //User dtoModel = MyMapper.Map<User, Student>(student, map =>
        //{
        //    map.ForMember(dest => dest.idNumber, opt => opt.MapFrom(src => src.Id));
        //    map.ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.Name));
        //    map.ForMember(dest => dest.userPhoneNumber, opt => opt.MapFrom(src => src.phoneNumber));
        //});
        //Console.WriteLine(result);
        //Console.WriteLine(dtoModel);
    }
    
}
