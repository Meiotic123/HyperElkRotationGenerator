string currentDir = AppDomain.CurrentDomain.BaseDirectory;

string universalDir = System.IO.Path.Combine(currentDir, @"..\..\..\Universal");
string rotationDir = System.IO.Path.Combine(currentDir, @"..\..\..\GeneratedRotations");
string baseClassesDir = System.IO.Path.Combine(currentDir, @"..\..\..\BaseClasses");
string specializationDir = System.IO.Path.Combine(currentDir, @"..\..\..\Specializations");

Directory.CreateDirectory(rotationDir);

string[] universalFiles = Directory.GetFiles(universalDir);
string[] rotationFiles = Directory.GetFiles(rotationDir);
string[] specializationFiles = Directory.GetFiles(specializationDir);

Array.Reverse(universalFiles); // Quick and dirty way to make sure UniversalRotation gets written first since it has the imports.

foreach (string rotationFile in rotationFiles)
{
    File.Delete(rotationFile);
}


foreach (string specializationFile in specializationFiles)
{
    string baseClass = "";
    string baseClassPath = "";
    var lines = File.ReadLines(specializationFile);
    
    foreach (string line in lines)
    {
        if (line.Contains("public class"))
        {
            baseClass = line.Split(": ")[1];
            baseClass += ".cs";
            baseClassPath = baseClassesDir + @"\" +  baseClass;
            break;
        }
    }

    string outputFile = specializationFile.Split(@"\").Last();
    string outputDir = rotationDir + @"\" + outputFile;

    string copyLines = "";

    // Add Universal Files
    foreach (string universalFile in universalFiles)
    {
        if (universalFile.Contains("UniversalRoutine.cs"))
        {
            lines = File.ReadLines(universalFile);
            
            foreach (string line in lines)
            {
                if (line.Contains("//_class = new UniversalRoutine(true)"))
                {
                    string replacement = "_class = new " + baseClass.Split(".")[0] + "(true)" + "\n";
                    string replacedLine = line.Replace("//_class = new UniversalRoutine(true)", replacement);
                    copyLines += replacedLine;
                }
                else if (line.Contains("//_spec = new UniversalRoutine()"))
                {
                    string replacement = "_spec = new " + outputFile.Split(".")[0] + "()" + "\n";
                    string replacedLine = line.Replace("//_spec = new UniversalRoutine()", replacement);
                    copyLines += replacedLine;
                }
                else
                {
                    copyLines += line + "\n";
                }
                
            }
            File.AppendAllText(outputDir, copyLines);
        }
        else
        {
            string fileContents = File.ReadAllText(universalFile);
            File.AppendAllText(outputDir, fileContents);
        }
    }

    // Add Class File
    lines = File.ReadLines(baseClassPath);
    copyLines = "";
    foreach (string line in lines)
    {
        if (!line.Contains("using"))
        {
            copyLines += line + "\n";
        }
    }
    File.AppendAllText(outputDir, copyLines);

    // Add Specialization File
    lines = File.ReadLines(specializationFile);
    copyLines = "";
    foreach (string line in lines)
    {
        if (!line.Contains("using"))
        {
            copyLines += line + "\n";
        }
    }
    File.AppendAllText(outputDir, copyLines);
}