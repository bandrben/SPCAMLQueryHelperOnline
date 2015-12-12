using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("SPCAMLQueryHelperOnline")]
[assembly: AssemblyDescription(@"Use this program to build and test CAML queries for SharePoint.  Compatible with SharePoint 2013.


Sample Queries:


<Where>
  <Or>
     <Geq>
         <FieldRef Name='Field1'/>
         <Value Type='Number'>1500</Value>
     </Geq>
     <Leq>
        <FieldRef Name='Field2'/><Value Type='Number'>500</Value>
     </Leq>
   </Or>
</Where>


<Where>
   <And>
       <BeginsWith>
              <FieldRef Name=""Conference""/>
              <Value Type=""Note"">Morning</Value>
       </BeginsWith>
       <Contains>
              <FieldRef Name=""Conference"" />
              <Value Type=""Note"">discussion session</Value>
       </Contains>
   </And>
</Where>


Comparison Operators:

<BeginsWith>
	<FieldRef>
	<Value>
<Contains>
	<FieldRef>
	<Value>
<DateRangesOverlap>
	<FieldRef>
	<Value>
<Eq>
	<FieldRef>
	<Value>
<Geq>
	<FieldRef>
	<Value>
<Gt>
	<FieldRef>
	<Value>
<In>
	<FieldRef>
	<Values>
	<Value>
<Includes>
	<FieldRef>
	<Value>
<IsNotNull>
	<FieldRef>
<IsNull>
	<FieldRef>
<Leq>
	<FieldRef>
	<Value>
<Lt>
	<FieldRef>
	<Value>
<Membership>
<Neq>
	<FieldRef>
	<Value>
<NotIncludes>
	<FieldRef>
	<Value>


XML Replacement Chars:
"" \""
\ \\
+ \u002b
> \u003e
< \u003c
' \u0027")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("B&&R Business Solutions, Authored by Ben Steinhauser")]
[assembly: AssemblyProduct("SPCAMLQueryHelperOnline")]
[assembly: AssemblyCopyright("Copyright 2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("3c26177f-9a5c-401d-b072-6bc913342440")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
