# C-SQLCSV-ReadApp

Create a Windows application in Visual Studio that reads the contents of a CSV file (delimited file) and writes data to an MSSQL data table. Also, perform the reverse operation MSSQL -> CSV sorted by the TagName field.
 
Example csv file content (content in red):
TagName, Type, Value
Boiler.P1.Value, Float, 3.4
Boiler.P2.Value, Float, 3.2
Boiler.T1.SP, Int, 83

Made in C #
This application has the following disadvantages:
1. We had to remove spaces from the header (first line) of the csv file (In C #, you can write an algorithm that can read and identify records, but due to the small scale this is not required).
2. In the csv file, when writing back data from sql, empty lines are not set, since when sorting empty values ​​are grouped first, the header (first line) will simply be removed from the main content.

Создать Windows-приложение в Visual Studio, обеспечивающее чтение содержимого CSV-файла (файл с разделителями) и запись данных в таблицу данных MSSQL. Также выполнить обратную операцию MSSQL -> CSV c сортировкой по полю TagName.
 
Пример содержимого файла csv(содержимое выделено красным):
TagName, Type, Value
Boiler.P1.Value, Float, 3.4
Boiler.P2.Value, Float, 3.2
Boiler.T1.SP,  Int, 83

Выполнено на C#
У данного приложения есть следующие недостатки:
1.	Из заголовка (первой строки) csv-файла пришлось убрать пробелы (На C# можно написать алгоритм, способный прочитывать и идентифицировать записи, но ввиду небольшого масштаба это не потребуется).
2.	В csv-файле при обратной записи данных из sql не ставятся пустые строки, ввиду того что при сортировке пустые значения группируются первыми заголовок (первая строка) просто будет отдалена от основного содержания.


