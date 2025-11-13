<a name='assembly'></a>
# Vsxmd

## Contents

- [Converter](#T-Vsxmd-Converter 'Vsxmd.Converter')
  - [#ctor(document)](#M-Vsxmd-Converter-#ctor-System-Xml-Linq-XDocument- 'Vsxmd.Converter.#ctor(System.Xml.Linq.XDocument)')
  - [#ctor(document,assemblyPath)](#M-Vsxmd-Converter-#ctor-System-Xml-Linq-XDocument,System-String- 'Vsxmd.Converter.#ctor(System.Xml.Linq.XDocument,System.String)')
  - [ToMarkdown(document)](#M-Vsxmd-Converter-ToMarkdown-System-Xml-Linq-XDocument- 'Vsxmd.Converter.ToMarkdown(System.Xml.Linq.XDocument)')
  - [ToMarkdown()](#M-Vsxmd-Converter-ToMarkdown 'Vsxmd.Converter.ToMarkdown')
- [IConverter](#T-Vsxmd-IConverter 'Vsxmd.IConverter')
  - [ToMarkdown()](#M-Vsxmd-IConverter-ToMarkdown 'Vsxmd.IConverter.ToMarkdown')

<a name='T-Vsxmd-Converter'></a>
## Converter `type`

##### Namespace

Vsxmd

##### Summary

*Inherit from parent.*

<a name='M-Vsxmd-Converter-#ctor-System-Xml-Linq-XDocument-'></a>
### #ctor(document) `constructor`

##### Summary

Initializes a new instance of the [Converter](#T-Vsxmd-Converter 'Vsxmd.Converter') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [System.Xml.Linq.XDocument](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument') | The XML document. |

<a name='M-Vsxmd-Converter-#ctor-System-Xml-Linq-XDocument,System-String-'></a>
### #ctor(document,assemblyPath) `constructor`

##### Summary

Initializes a new instance of the [Converter](#T-Vsxmd-Converter 'Vsxmd.Converter') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [System.Xml.Linq.XDocument](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument') | The XML document. |
| assemblyPath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The path to the assembly DLL file for filtering public APIs. If null, all members are included. |

<a name='M-Vsxmd-Converter-ToMarkdown-System-Xml-Linq-XDocument-'></a>
### ToMarkdown(document) `method`

##### Summary

Convert VS XML document to Markdown syntax.

##### Returns

The generated Markdown content.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [System.Xml.Linq.XDocument](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument') | The XML document. |

<a name='M-Vsxmd-Converter-ToMarkdown'></a>
### ToMarkdown() `method`

##### Summary

*Inherit from parent.*

##### Parameters

This method has no parameters.

<a name='T-Vsxmd-IConverter'></a>
## IConverter `type`

##### Namespace

Vsxmd

##### Summary

Converter for XML document to Markdown syntax conversion.

<a name='M-Vsxmd-IConverter-ToMarkdown'></a>
### ToMarkdown() `method`

##### Summary

Convert to Markdown syntax.

##### Returns

The generated Markdown content.

##### Parameters

This method has no parameters.
