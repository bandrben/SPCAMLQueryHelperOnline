using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SPCAMLQueryHelperOnline
{
    class CamlExamples
    {


        public static Dictionary<string, string> GetCamlExamples(bool addQuery)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();


            d.Add("Replace with: Order/Where/And", (addQuery ? "<Query>" + Environment.NewLine : "") + @"<OrderBy>
  <FieldRef Name=""Modified"" Ascending=""FALSE""></FieldRef>
</OrderBy>
<Where>
  <And>
    <BeginsWith>
      <FieldRef Name=""Title""></FieldRef>
      <Value Type=""Text"">A</Value>
    </BeginsWith>
    <IsNotNull>
      <FieldRef Name=""Title""></FieldRef>
    </IsNotNull>
  </And>
</Where>" + (addQuery ? Environment.NewLine + "</Query>" : ""));


            d.Add("Replace with: Order/Where/And(2)/Or", (addQuery ? "<Query>" + Environment.NewLine : "") + @"<OrderBy>
  <FieldRef Name=""Modified"" Ascending=""FALSE""></FieldRef>
</OrderBy>
<Where>
  <And>
    <And>
      <BeginsWith>
        <FieldRef Name=""Title""></FieldRef>
        <Value Type=""Text"">A</Value>
      </BeginsWith>
      <IsNotNull>
        <FieldRef Name=""Title""></FieldRef>
      </IsNotNull>
    </And>
    <Or>
      <BeginsWith>
        <FieldRef Name=""Title""></FieldRef>
        <Value Type=""Text"">B</Value>
      </BeginsWith>
      <IsNotNull>
        <FieldRef Name=""Title""></FieldRef>
      </IsNotNull>
    </Or>
  </And>
</Where>" + (addQuery ? Environment.NewLine + "</Query>" : ""));


            d.Add("Replace with: Simple Where", (addQuery ? "<Query>" + Environment.NewLine : "") + @"<Where>
  <IsNotNull>
    <FieldRef Name=""ID"" />
  </IsNotNull>
</Where>" + (addQuery ? Environment.NewLine + "</Query>" : ""));

            d.Add("Replace with: Simple Where 2", (addQuery ? "<Query>" + Environment.NewLine : "") + @"<Where>
  <Eq>
    <FieldRef Name=""Title""></FieldRef>
    <Value Type=""Text"">Test</Value>
  </Eq>
</Where>" + (addQuery ? Environment.NewLine + "</Query>" : ""));

            d.Add("Replace with: Simple Where 3", (addQuery ? "<Query>" + Environment.NewLine : "") + @"<Where>
  <BeginsWith>
    <FieldRef Name=""Title""></FieldRef>
    <Value Type=""Text"">A</Value>
  </BeginsWith>
</Where>" + (addQuery ? Environment.NewLine + "</Query>" : ""));

            d.Add("Replace with: Simple Where 4", (addQuery ? "<Query>" + Environment.NewLine : "") + @"<Where>
  <Or>
    <Eq>
      <FieldRef Name=""Title""></FieldRef>
      <Value Type=""Text"">Test</Value>
    </Eq>
    <IsNotNull>
      <FieldRef Name=""Title""></FieldRef>
    </IsNotNull>
  </Or>
</Where>" + (addQuery ? Environment.NewLine + "</Query>" : ""));

            return d;
        }


    }
}
