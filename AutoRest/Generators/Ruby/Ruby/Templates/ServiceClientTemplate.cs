// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.Generator.Ruby.Templates
{
#line 1 "ServiceClientTemplate.cshtml"
using Microsoft.Rest.Generator.Ruby

#line default
#line hidden
    ;
#line 2 "ServiceClientTemplate.cshtml"
using Microsoft.Rest.Generator.Ruby.Templates

#line default
#line hidden
    ;
#line 3 "ServiceClientTemplate.cshtml"
using Microsoft.Rest.Generator.Utilities

#line default
#line hidden
    ;
#line 4 "ServiceClientTemplate.cshtml"
using System.Linq

#line default
#line hidden
    ;
#line 5 "ServiceClientTemplate.cshtml"
using Microsoft.Rest.Generator.Ruby.TemplateModels

#line default
#line hidden
    ;
    using System.Threading.Tasks;

    public class ServiceClientTemplate : Microsoft.Rest.Generator.Template<Microsoft.Rest.Generator.Ruby.ServiceClientTemplateModel>
    {
        #line hidden
        public ServiceClientTemplate()
        {
        }

        #pragma warning disable 1998
        public override async Task ExecuteAsync()
        {
#line 7 "ServiceClientTemplate.cshtml"
Write(Header("# "));

#line default
#line hidden
            WriteLiteral("\r\n");
#line 8 "ServiceClientTemplate.cshtml"
Write(EmptyLine);

#line default
#line hidden
            WriteLiteral("\r\nmodule ");
#line 9 "ServiceClientTemplate.cshtml"
  Write(Settings.Namespace);

#line default
#line hidden
            WriteLiteral("\r\n  #\r\n  # A service client - single point of access to the REST API.\r\n  #\r\n  cla" +
"ss ");
#line 13 "ServiceClientTemplate.cshtml"
   Write(Model.Name);

#line default
#line hidden
            WriteLiteral(" < ");
#line 13 "ServiceClientTemplate.cshtml"
                 Write(Model.BaseType);

#line default
#line hidden
            WriteLiteral("\r\n    # @return [String] the base URI of the service.\r\n    attr_accessor :base_ur" +
"l\r\n");
#line 16 "ServiceClientTemplate.cshtml"
Write(EmptyLine);

#line default
#line hidden
            WriteLiteral("\r\n\r\n");
#line 18 "ServiceClientTemplate.cshtml"
 foreach (var property in Model.Properties)
{

#line default
#line hidden

            WriteLiteral("    ");
#line 20 "ServiceClientTemplate.cshtml"
 Write(WrapComment("# ", string.Format("@return {0}{1}", property.Type.GetYardDocumentation(), property.Documentation)));

#line default
#line hidden
            WriteLiteral("\r\n    ");
#line 21 "ServiceClientTemplate.cshtml"
  Write(property.IsReadOnly ? "attr_reader" : "attr_accessor");

#line default
#line hidden
            WriteLiteral(" :");
#line 21 "ServiceClientTemplate.cshtml"
                                                           Write(property.Name);

#line default
#line hidden
            WriteLiteral("\r\n");
#line 22 "ServiceClientTemplate.cshtml"

#line default
#line hidden

#line 22 "ServiceClientTemplate.cshtml"
Write(EmptyLine);

#line default
#line hidden
#line 22 "ServiceClientTemplate.cshtml"
          
}

#line default
#line hidden

            WriteLiteral("\r\n");
#line 25 "ServiceClientTemplate.cshtml"
 foreach (var operation in Model.MethodGroups) 
{

#line default
#line hidden

            WriteLiteral("    ");
#line 27 "ServiceClientTemplate.cshtml"
 Write(WrapComment("# ", string.Format("@return {0}", RubyCodeNamer.UnderscoreCase(operation))));

#line default
#line hidden
            WriteLiteral("\r\n    attr_reader :");
#line 28 "ServiceClientTemplate.cshtml"
               Write(RubyCodeNamer.UnderscoreCase(operation));

#line default
#line hidden
            WriteLiteral("\r\n");
#line 29 "ServiceClientTemplate.cshtml"

#line default
#line hidden

#line 29 "ServiceClientTemplate.cshtml"
Write(EmptyLine);

#line default
#line hidden
#line 29 "ServiceClientTemplate.cshtml"
          
}

#line default
#line hidden

            WriteLiteral("\r\n    #\r\n    # Creates initializes a new instance of the ");
#line 33 "ServiceClientTemplate.cshtml"
                                           Write(Model.Name);

#line default
#line hidden
            WriteLiteral(@" class.
    # @param credentials [ClientRuntime::ServiceClientCredentials] credentials to authorize HTTP requests made by the service client.
    # @param base_url [String] the base URI of the service.
    # @param options [Array] filters to be applied to the HTTP requests.
    #
    def initialize(credentials, base_url = nil, options = nil)
      super(credentials, options)
      @base_url = base_url || '");
#line 40 "ServiceClientTemplate.cshtml"
                           Write(Model.BaseUrl);

#line default
#line hidden
            WriteLiteral("\'\r\n      ");
#line 41 "ServiceClientTemplate.cshtml"
 Write(EmptyLine);

#line default
#line hidden
            WriteLiteral("\r\n      fail ArgumentError, \'credentials is nil\' if credentials.nil?\r\n      fail " +
"ArgumentError, \'invalid type of credentials input parameter\' unless credentials." +
"is_a?(ClientRuntime::ServiceClientCredentials)\r\n      @credentials = credentials" +
"\r\n      ");
#line 45 "ServiceClientTemplate.cshtml"
 Write(EmptyLine);

#line default
#line hidden
            WriteLiteral("\r\n");
#line 46 "ServiceClientTemplate.cshtml"
      

#line default
#line hidden

#line 46 "ServiceClientTemplate.cshtml"
       foreach (var operation in Model.MethodGroups) 
      {

#line default
#line hidden

            WriteLiteral("      @");
#line 48 "ServiceClientTemplate.cshtml"
      Write(RubyCodeNamer.UnderscoreCase(operation));

#line default
#line hidden
            WriteLiteral(" = ");
#line 48 "ServiceClientTemplate.cshtml"
                                                   Write(operation);

#line default
#line hidden
            WriteLiteral(".new(self)\r\n");
#line 49 "ServiceClientTemplate.cshtml"
      }

#line default
#line hidden

            WriteLiteral("    end\r\n\r\n    ");
#line 52 "ServiceClientTemplate.cshtml"
Write(EmptyLine);

#line default
#line hidden
            WriteLiteral("\r\n");
#line 53 "ServiceClientTemplate.cshtml"
    

#line default
#line hidden

#line 53 "ServiceClientTemplate.cshtml"
     foreach (var method in Model.MethodTemplateModels)
    {

#line default
#line hidden

            WriteLiteral("    ");
#line 55 "ServiceClientTemplate.cshtml"
  Write(Include(new MethodTemplate(), method));

#line default
#line hidden
            WriteLiteral("\r\n");
#line 56 "ServiceClientTemplate.cshtml"
    

#line default
#line hidden

#line 56 "ServiceClientTemplate.cshtml"
Write(EmptyLine);

#line default
#line hidden
#line 56 "ServiceClientTemplate.cshtml"
              

#line default
#line hidden

            WriteLiteral("    \r\n");
#line 58 "ServiceClientTemplate.cshtml"
    }

#line default
#line hidden

            WriteLiteral("  end\r\nend\r\n");
        }
        #pragma warning restore 1998
    }
}
