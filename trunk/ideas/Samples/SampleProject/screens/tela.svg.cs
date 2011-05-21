<?xml version="1.0" encoding="ISO-8859-1" standalone="no"?> 
<!DOCTYPE svg PUBLIC "-//W3C//DTD SVG 20010904//EN"
    "http://www.w3.org/TR/2001/REC-SVG-20010904/DTD/svg10.dtd"> 
<svg onload="init(evt)" xmlns="http://www.w3.org/2000/svg"
     xmlns:xlink="http://www.w3.org/1999/xlink" xml:space="preserve"
         width="100%" height="100%"> 
	
	<!-- Matthew Bystedt http://apike.ca 2005 --> 
 
    <script type="text/ecmascript"><![CDATA[
 
	function init(evt) {
		if ( window.svgDocument == null )
		{
			svgDocument = evt.target.ownerDocument;
		}
		
		updateVars();
	}

	var click       = 0;
	var mouseDown   = 0;
	var mouseUp     = 0;
	var mouseOver   = 0;
	var mouseMove   = 0;
	var mouseOut    = 0;

	var TAGS = [];
       
	function updateVars() 
	{
		for(i = 0; i < 20; i++)
		{
			TAGS[i] = Math.floor(Math.random()*101);
		}

		updateStats();
		
		setTimeout ( "updateVars()", 1000 );
	}
    
	function updateStats()
	{
		for(i = 0; i < 20; i++)
		{
			var object = svgDocument.getElementById("Label" + (i + 1));
			if(object != null)
			{
				object.firstChild.data = TAGS[i];
			}
		}
	}
    
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
    
    
 
    ]]></script> 
	
	<!-- Pattern Definition --> 
	<defs> 
		<pattern id="checkerPattern" patternUnits="userSpaceOnUse"
				x="0" y="0" width="10" height="10"
				viewBox="0 0 10 10" > 
				
			<rect x="0" y="0" width="5" height="5" fill="lightblue" /> 
			<rect x="5" y="5" width="5" height="5" fill="lightblue" /> 
		</pattern> 
	</defs> 
 
	<!-- Background --> 
	<rect x="-200" y="0" width="100" height="200" fill="url(#checkerPattern)" /> 
 
	<!-- Javascript Example --> 
 
	<circle cx="50%" cy="25%" r="40" fill="lightyellow" stroke-width="1" stroke="black"
		onclick="msClick()"
		onmousedown="msDown()"
		onmouseup="msUp()"
		onmouseover="msOver()"
		onmousemove="msMove()"
		onmouseout="msOut()" /> 
 
	<rect x="5" y="95" width="130" height="95" fill="white" stroke="grey" stroke-width="2" rx="10" ry="10" opacity="0.5" /> 
 
	<text x="10" y="110" id="clicks">onclick = 0</text> 
	<text x="10" y="125" id="mousedowns">onmousedown = 0</text> 
	<text x="10" y="140" id="mouseups">onmouseup = 0</text> 
	<text x="10" y="155" id="mouseovers">onmouseover = 0</text> 
	<text x="10" y="170" id="mousemoves">onmousemove = 0</text> 
	<text x="10" y="185" id="mouseouts">onmouseout = 0</text>

	<rect x="5" y="300" width="130" height="500" fill="white" stroke="grey" stroke-width="2" rx="10" ry="10" opacity="0.5" /> 

	<text x="10" y="315" id="Label1">Label1</text> 
	<text x="10" y="330" id="Label2">Label1</text> 
	<text x="10" y="345" id="Label3">Label1</text> 
	<text x="10" y="360" id="Label4">Label1</text> 
	<text x="10" y="375" id="Label5">Label1</text> 
	<text x="10" y="390" id="Label6">Label1</text>
	<text x="10" y="405" id="Label7">Label1</text>
	<text x="10" y="420" id="Label8">Label1</text>
	<text x="10" y="435" id="Label9">Label1</text>
	<text x="10" y="450" id="Label10">Label1</text>
	<text x="10" y="465" id="Label11">Label1</text>
	<text x="10" y="480" id="Label12">Label1</text>
	<text x="10" y="495" id="Label13">Label1</text>
	<text x="10" y="510" id="Label14">Label1</text>
	<text x="10" y="525" id="Label15">Label1</text>
	<text x="10" y="540" id="Label16">Label1</text>
	<text x="10" y="555" id="Label17">Label1</text>
	<text x="10" y="570" id="Label18">Label1</text>
	<text x="10" y="585" id="Label19">Label1</text>
	<text x="10" y="600" id="Label20">Label1</text>
	
 
</svg>