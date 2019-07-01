using CQRS.Commands;
using System;
using System.IO;

namespace DomainModel.CQRS.Commands.CreateFileWithContent
{
    public class CreateFileWithContentCommandHandler : ICommandHandler<CreateFileWithContentCommand>
    {
        public void Handle(CreateFileWithContentCommand command)
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("C:\\windows\\temp\\Test.txt");

                //Write a line of text
                sw.WriteLine(command.Content);

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
