using BJET.CodeSamurai.Services;

// PROBLEM 1
//TaskDependencyService taskDependencyService = new();
//taskDependencyService.TaskThread();


// PROBLEM 2
//EstimatedHourService estimatedHourService = new();
//estimatedHourService.EstimatedHourCalculation();

//problem 3

// NewResourseTypeService newResourseTypeService = new();
// newResourseTypeService.Check();


var text="Jane's name";
bool i = text.Contains("'");
if(i){
    text=text.Replace("'", "_");
}

Console.WriteLine(text);


