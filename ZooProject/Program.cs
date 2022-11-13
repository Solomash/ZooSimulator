// See https://aka.ms/new-console-template for more information

using ZooCommonLibrary.Common.Exceptions.Cage;
using ZooProject.Application;

try
{
    var zoo = ZooBuilder.Create();
}
catch (CageOverFlowException ex)
{
    Console.WriteLine("Решить проблему с расслением зверей! " + ex.Message);
}
