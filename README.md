<h1>What is HyperElkRotationGenerator?</h1>

HyperElkRotationGenerator is a framework to build HyperElk rotation scripts in a OOP fashion. This is only necessary because we cannot package rotations up as .dll's do to HyperELk's limitation on community rotations.

A very barebones Frost DK sample has been left in as an example. This example contains no rotation logic, but will show you the basics of how to utilize this tool.

<h1>Architecture</h1>

RotationGenerator -> Logic to generate the actual rotations.

Universal -> Houses all of your classes that will be included in every rotation.

BaseClasses -> Where you add class specific logic for a rotation. A single base class should get used per rotation.

Specalizations -> Where you add spec specific logic for a rotation. A single spec class should get used per rotation.

<h1>How to use</h1>

Step 1: Clone down the repo.

Step 2: Open the visual studios solution file.

Step 3: In the solution explorer, right click and select Add Project Reference.

Step 4: Navigate to your HyperElk install foloder, go to the API folder, and select DemoAPI.dll and select ok.

Step 5: Build and run the project.

Step 6: The first time it runs, a new folder will be created called "GeneratedRotations". Right click it and select "Exclude from project".

Step 7: Within HyperElk, navigate to your new custom rotation folder and select the appropriate rotation for your current class/spec.
