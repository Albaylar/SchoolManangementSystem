namespace SchoolPlus
{
    internal class Program
    {

        static School school;

        static void Main (string[] args)
        {
            school = new School();
            school.Run();
        }
    }
}