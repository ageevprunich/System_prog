using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_6
{
    public partial class Form1 : Form
    {

        public class DeskLamp
        {

            public string Model { get; set; }
            public int Brightness { get; set; }
            public bool IsOn { get; set; }
            public List<string> LightModes { get; set; }

            // Default constructor
            public DeskLamp()
            {
                Model = "Unnamed";
                Brightness = 0;
                IsOn = false;
                LightModes = new List<string> { "Standard", "Night", "Bright" };
            }

            // Constructor with parameters
            public DeskLamp(string model, int brightness, bool isOn, List<string> lightModes)
            {
                Model = model;
                Brightness = brightness;
                IsOn = isOn;
                LightModes = lightModes;
            }

            // Methods
            public void TurnOn()
            {
                IsOn = true;
            }


            public void TurnOff()
            {
                IsOn = false;
            }


            public void ChangeBrightness(int newBrightness)
            {
                Brightness = newBrightness;
            }
        }

        public class ReflectionHelper
        {
            public static void DisplayClassInfoInTreeView(object obj, TreeView treeView)
            {
                treeView.Nodes.Clear();

                if (obj == null) return;

                Type type = obj.GetType();
                TreeNode classNode = new TreeNode(type.Name);
                treeView.Nodes.Add(classNode);

                // --- Properties ---
                TreeNode propertiesNode = new TreeNode("Properties");
                classNode.Nodes.Add(propertiesNode);

                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    object value = property.GetValue(obj, null);
                    string displayValue = value is System.Collections.IEnumerable && !(value is string)
                        ? "(Collection)"
                        : value?.ToString() ?? "null";

                    TreeNode propertyNode = new TreeNode($"{property.PropertyType.Name} {property.Name} = {displayValue}");
                    propertiesNode.Nodes.Add(propertyNode);

                    if (value is System.Collections.IEnumerable collection && !(value is string))
                    {
                        foreach (var item in collection)
                        {
                            propertyNode.Nodes.Add(new TreeNode(item?.ToString() ?? "null"));
                        }
                    }
                }

                // --- Constructors ---
                TreeNode constructorsNode = new TreeNode("Constructors");
                classNode.Nodes.Add(constructorsNode);

                ConstructorInfo[] constructors = type.GetConstructors();
                foreach (ConstructorInfo ctor in constructors)
                {
                    string ctorSignature = $"{type.Name}(";
                    ParameterInfo[] parameters = ctor.GetParameters();
                    ctorSignature += string.Join(", ", parameters.Select(p => $"{p.ParameterType.Name} {p.Name}"));
                    ctorSignature += ")";
                    constructorsNode.Nodes.Add(new TreeNode(ctorSignature));
                }

                // --- Methods ---
                TreeNode methodsNode = new TreeNode("Methods");
                classNode.Nodes.Add(methodsNode);

                MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (MethodInfo method in methods)
                {
                    string methodSignature = $"{method.ReturnType.Name} {method.Name}(";
                    ParameterInfo[] parameters = method.GetParameters();
                    methodSignature += string.Join(", ", parameters.Select(p => $"{p.ParameterType.Name} {p.Name}"));
                    methodSignature += ")";
                    methodsNode.Nodes.Add(new TreeNode(methodSignature));
                }

                classNode.ExpandAll();
            }

        }

        public Form1()
            {
            InitializeComponent();
            DeskLamp lamp1 = new DeskLamp("IKEA L123", 450, true, new List<string> { "Eco", "Reading", "Relax" });
            DeskLamp lamp2= new DeskLamp("JUSK ECO", 300, false, new List<string> { "Day light", "Eco", "Ambiant" });

            ReflectionHelper.DisplayClassInfoInTreeView(lamp1, treeView1);
            }

            private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
            {

            }

        
    }

}



