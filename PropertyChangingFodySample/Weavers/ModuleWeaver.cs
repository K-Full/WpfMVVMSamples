using Mono.Cecil;
using PropertyChanging;

//public class ModuleWeaver
//{
//    public ModuleDefinition ModuleDefinition { get; set; }

//    public void Execute()
//    {
//        ModuleDefinition.Types.Add(new TypeDefinition("PropertyChanging", "ImplementPropertyChangingAttribute", TypeAttributes.Public, ModuleDefinition.Import(typeof(object))));
//    }
//}

public class ModuleWeaver
{
    public ModuleDefinition ModuleDefinition { get; set; }

    public void Execute() { }
}
