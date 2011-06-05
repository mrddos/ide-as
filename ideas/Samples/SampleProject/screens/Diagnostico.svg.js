/*
	Ideas.Scada.Server - 2011
	
	Screen: Diagnostico
	File: Diagnostico.svg.js (Client-side script)
	Application: SampleApplication
	Project: SampleProject
	Author: Luiz Can�ado
	Description: A sample client-side script to demonstrate IDEAS application structure.
*/

var click = 0;
var mouseDown = 0; 
var mouseUp = 0;
var mouseOver = 0;
var mouseMove = 0;
var mouseOut = 0;
var textbutton1;

//now create a new button instance
function initScreen(evt)
{
	textbutton1 = 
		new button(
			"Botao1",
			"Botao",
			GotoScreen,
			"rect",
			"Click me",
			undefined,
			500,
			300,
			100,
			30,
			{"font-family":"Arial,Helvetica","fill":"navy","font-size":12},
			{"fill":"lightsteelblue"},
			{"fill":"white"},
			{"fill":"navy"},
			1);

	updateVars();
}

function updateVars() 
{
	ReadTagList();

	updateStats();
	
	setTimeout ( "updateVars()", 1000 );
}
    
function updateStats()
{
	for(key in TAGS)
	{
		var object = svgDocument.getElementById(key + "_value");
		if(object != null)
		{
			object.firstChild.data = TAGS[key];
		}
	}
}


// Event Circle - Functions -- START

function updateCounters() 
{
	svgDocument.getElementById("clicks").firstChild.data = "onclick = " + click;
	svgDocument.getElementById("mousedowns").firstChild.data = "onmousedown = " + mouseDown;
	svgDocument.getElementById("mouseups").firstChild.data = "onmouseup = " + mouseUp;
	svgDocument.getElementById("mouseovers").firstChild.data = "onmouseover = " + mouseOver;
	svgDocument.getElementById("mousemoves").firstChild.data = "onmousemove = " + mouseMove;
	svgDocument.getElementById("mouseouts").firstChild.data = "onmouseout = " + mouseOut;
}
    
function msClick (evt) {
	click++;
	updateCounters();
}
 
function msDown (evt) {
	mouseDown++;
	updateCounters();
}

function msUp (evt) {
	mouseUp++;
	updateCounters();
}

function msOver (evt) {
	mouseOver++;
	updateCounters();
}

function msMove (evt) {
	mouseMove++;
	updateCounters();
}

function msOut (evt) {
	mouseOut++;
	updateCounters();
}

// Event Circle - Functions -- END