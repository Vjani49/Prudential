# Prudential

Prudential.zip file contains 3 folders.
1.	InputFolder:
a.	Create folders according to this path ‘E:\Prudential\InputFolder\City' and add file named as Data.txt.
b.	This will be taken as input for the utility. 
c.	If needed, change path to appropriate location of varibale named 'cityNamesData' for input 

2.	OutputFolder:
a.	This will be created automatically by utility. 
b.	All the output files will be created under respective city names folder.

3.	CityWeatherAnalysis:
a.	This is the utility which will import city data, perform API call and store output.
b.	To run utility, execute the EXE from folder 'CityWeatherAnalysis\CityWeatherAnalysis\bin\Debug'
Test Cases
1.	Check if the input file exists or not. In case if the file is not available, a console error will be printed.
 

2.	In case of invalid city id or API call, appropriate message will be printed on Console.
a.	In valid city ID – Error log
 

b.	Improper AppID – Error log
 

3.	In case of improper city ID from input file, utility will give appropriate message on console.
 

Final Output:
1.	Output will be stored in ‘E:\Prudential\OutputFolder’.
2.	A folder for each city will be generated.
 

3.	In the respective city name folder data for each day will be stored in json file.
 
