using SingleResponsability;

StudentRepository studentRepository = new();
ExportHelper<Student> exportHelper = new();
exportHelper.ExportToCSV(studentRepository.GetAll());
Console.WriteLine("Proceso Completado");