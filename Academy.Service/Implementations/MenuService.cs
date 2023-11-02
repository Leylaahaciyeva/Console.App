using System;
using Academy.Core.Enums;
using Academy.Service.Interfaces;
using Academy.Service.Implementations;


namespace Academy.Service.Implementations
{
	public class MenuService
	{
        IStudentService studentService = new StudentService();
        public async Task  RunApp()
        {

            

            await Menu();
            string request = Console.ReadLine();

            while (request != "0")
            {
                switch (request)
                {
                    case "1":
                        await CreateStudent();
                        break;
                    case "2":
                        await UpdateStudent();
                        break;
                    case "3":
                        await RemoveStudent();
                        break;
                    case "4":
                       await Get();
                        break;
                    case "5":
                        await GetAllStudent();
                        break;
                    default:
                        break;
                }
                await Menu();
                request = Console.ReadLine();
            }


}

         async Task CreateStudent()
{
    Console.WriteLine("Add FullName");
    string FullName = Console.ReadLine();
    Console.WriteLine("Add Group");
    string Group = Console.ReadLine();
    Console.WriteLine("Add Average");
    int.TryParse(Console.ReadLine(), out int Average);
    int i = 1;
    foreach (var item in Enum.GetValues(typeof(Education)))
    {

        Console.WriteLine($"{i}.{item}");
        i++;
    }


    bool IsExsist;
    int EnumIndex;
    do
    {
        Console.WriteLine("Add Education");
        int.TryParse(Console.ReadLine(), out EnumIndex);
        IsExsist = Enum.IsDefined(typeof(Education), (Education)EnumIndex);
    } while (!IsExsist);

    string result = await studentService.CreateAsync(FullName, Group, Average, (Education)EnumIndex);
    Console.WriteLine(result);
}
         async Task UpdateStudent()
        {
            Console.WriteLine("Add Id");
            string Id = Console.ReadLine();
            Console.WriteLine("Add FullName");
            string FullName = Console.ReadLine();
            Console.WriteLine("Add Group");
            string Group = Console.ReadLine();
            Console.WriteLine("Add Average");
            int.TryParse(Console.ReadLine(), out int Average);
            int i = 1;
            foreach (var item in Enum.GetValues(typeof(Education)))
            {

                Console.WriteLine($"{i}.{item}");
                i++;
            }


            bool IsExsist;
            int EnumIndex;
            do
            {
                Console.WriteLine("Add Education");
                int.TryParse(Console.ReadLine(), out EnumIndex);
                IsExsist = Enum.IsDefined(typeof(Education), (Education)EnumIndex);
            } while (!IsExsist);

            string result = await studentService.UpdateAsync(Id,FullName, Group, Average, (Education)EnumIndex);
            Console.WriteLine(result);
        }
         async Task RemoveStudent()
        {
            Console.WriteLine("Add Id");
            string Id = Console.ReadLine();

          string result= await studentService.RemoveAsync(Id);
            Console.WriteLine(result);

        }
         async Task GetAllStudent()
        {
            await studentService.GetAllAsync();
        }
         async Task Get()
        {
            Console.WriteLine("Add Id");
            string Id = Console.ReadLine();
            string result = await studentService.GetAsync(Id);
            Console.WriteLine(result);

        }
         async Task Menu()
{
    Console.WriteLine("1.Create");
    Console.WriteLine("2.Update");
    Console.WriteLine("3.Remove");
    Console.WriteLine("4.Get");
    Console.WriteLine("5.GetAll");
    Console.WriteLine("0.Close");
}
	}
}

