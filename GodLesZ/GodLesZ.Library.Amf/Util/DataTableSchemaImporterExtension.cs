
#if (NET_1_1)
    //NA
#else

using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Data;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.Serialization.Advanced;

namespace GodLesZ.Library.Amf.Util {
	/// <summary>
	/// Schema Importer Extension used for WebServices in order to recognize the schema for DataTable within wsdl
	/// </summary>
	class DataTableSchemaImporterExtension : SchemaImporterExtension {
		Hashtable importedTypes = new Hashtable();

		public override string ImportSchemaType(string name, string schemaNamespace, XmlSchemaObject context, XmlSchemas schemas, XmlSchemaImporter importer, CodeCompileUnit compileUnit, CodeNamespace mainNamespace, CodeGenerationOptions options, CodeDomProvider codeProvider) {
			IList values = schemas.GetSchemas(schemaNamespace);
			if (values.Count != 1) {
				return null;
			}
			XmlSchema schema = values[0] as XmlSchema;
			if (schema == null)
				return null;
			XmlSchemaType type = (XmlSchemaType)schema.SchemaTypes[new XmlQualifiedName(name, schemaNamespace)];
			return ImportSchemaType(type, context, schemas, importer, compileUnit, mainNamespace, options, codeProvider);
		}


		public override string ImportSchemaType(XmlSchemaType type, XmlSchemaObject context, XmlSchemas schemas, XmlSchemaImporter importer, CodeCompileUnit compileUnit, CodeNamespace mainNamespace, CodeGenerationOptions options, CodeDomProvider codeProvider) {
			if (type == null) {
				return null;
			}

			if (importedTypes[type] != null) {
				mainNamespace.Imports.Add(new CodeNamespaceImport(typeof(DataSet).Namespace));
				compileUnit.ReferencedAssemblies.Add("System.Data.dll");
				return (string)importedTypes[type];
			}
			if (!(context is XmlSchemaElement))
				return null;

			if (type is XmlSchemaComplexType) {
				XmlSchemaComplexType ct = (XmlSchemaComplexType)type;
				if (ct.Particle is XmlSchemaSequence) {
					XmlSchemaObjectCollection items = ((XmlSchemaSequence)ct.Particle).Items;
					if (items.Count == 2 && items[0] is XmlSchemaAny && items[1] is XmlSchemaAny) {
						XmlSchemaAny any0 = (XmlSchemaAny)items[0];
						XmlSchemaAny any1 = (XmlSchemaAny)items[1];
						if (any0.Namespace == XmlSchema.Namespace && any1.Namespace == "urn:schemas-microsoft-com:xml-diffgram-v1") {
							string typeName = typeof(DataTable).FullName;
							importedTypes.Add(type, typeName);
							mainNamespace.Imports.Add(new CodeNamespaceImport(typeof(DataTable).Namespace));
							compileUnit.ReferencedAssemblies.Add("System.Data.dll");
							return typeName;
						}
					}
				}
			}
			return null;
		}
	}
}
#endif
