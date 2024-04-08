![image](https://github.com/khairulanwar-mohdraya/CodedUIAutomation/assets/100569372/b3b59513-289e-4eb6-b930-5e1c4a670350)## Coded UI Test automation using Selenium, Specflow, and MSTest Framework with BDD approach.
This is a sample code of Visual Studio Solution to automate UI Testing using Behaviour Driven Development approach.
<br>

**Selenium:**
A web browser automation framework that can be used independently or alongside SpecFlow for automating browser interactions within the BDD tests.

**SpecFlow:**
SpecFlow is an open-source testing framework specifically designed for .NET environments that supports Behavior-Driven Development (BDD) practices. 
It provides a bridge between human-readable BDD practices and automated testing in .NET projects.

**Gherkin:**
Test Cases are written from a user's perspective, focusing on expected behavior instead of low-level implementation details.
It utilizes Gherkin, a human-readable language with keywords like "Given," "When," and "Then" to define test scenarios. 
Which will improve communication between developers, testers, and stakeholders.
Gherkin scenarios can serve also as living documentation that evolves with the application.

**Feature File:** 
Test scenarios are defined in plain text Feature files using Gherkin syntax. 
These files describe the features of the application from a user's perspective.

**Step Definitions File:**
These are code files written in C# that map the Gherkin steps to concrete actions. 
They interact with the application under test and verify the expected behavior.

**Test Execution:** 
SpecFlow integrates with MSTest runner to execute the test scenarios defined in the feature files.


<br>
**How it works?**
<br>

**SpecFlow (the Conductor):**
Interprets Gherkin: SpecFlow acts as the conductor, reading test scenarios written in Gherkin language within feature files.
BDD Bridge: It understands the human-readable steps defined with keywords like "Given," "When," and "Then."
Maps to Code: SpecFlow doesn't directly control the browser. Instead, it maps these Gherkin steps to corresponding code steps written in C#.

**Selenium (the Automation Engine):**
Browser Automation: The code steps implemented using Selenium take action.
Driver Interactions: Selenium provides the WebDriver API that allows your code to interact with the web browser.
Fulfilling Actions: Based on the instructions in the code steps, Selenium performs actions like opening URLs, clicking buttons, entering text, and verifying element states.

**Test results documentation**
**SpecFlow LivingDoc:**
The tool that extends SpecFlow which generates and manages interactive and dynamic documentation for the automated tests written in Gherkin syntax (using features, scenarios, and steps).
It transforms SpecFlow feature files into HTML pages, making them easier to read and understand for non-technical stakeholders. 
It also displays test results directly within the documentation and provides a clear picture of how well tests are performing and visualize passing scenarios, identify failures, and review execution details.
To generate the test result documentation, LivingDoc command-line tool is used or integration with the build process (like a post-build event in Visual Studio) to transform the SpecFlow feature files and test results into LivingDoc HTML documentation.


<br>
<br>
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
**How to run test using CLI**
1) Build the solution and go to the solution build folder path to run below command:

   dotnet test application.dll -l console -v detailed

2) After the test run is completed, check **TestExecution.json** file is generated in the build folder path

3) Run the below command to generate the Test result in HTML.
	
livingdoc feature-folder C:\sources\UITestAutomation\App\ -t C:\sources\UITestAutomation\App\bin\UAT\net7.0\TestExecution.json --output C:\sources\UITestAutomation\TestResults\TestAutomationResults.html

4) Open the TestAutomationResults.html in the folder path
