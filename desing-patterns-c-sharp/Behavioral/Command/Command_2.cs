using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desing_patterns_c_sharp.Behavioral.Command
{

    interface ICommandExe
    {
        void Execute();
    }

    class TextEditor
    {
        private string text = "";
        private string clipboard = "";
        private Stack<string> history = new();

        public void Type(char c)
        {
            history.Push(text);
            text += c;
        }

        public void Copy()
        {
            clipboard = text;
            Console.WriteLine($"Texto copiado al portapapeles: \"{clipboard}\"");
        }

        public void Paste()
        {
            history.Push(text);
            text += clipboard;
            Console.WriteLine($"Texto después de pegar: \"{text}\"");
        }

        public void Undo()
        {
            if (history.Count > 0)
            {
                text = history.Pop();
                Console.WriteLine($"Texto después de deshacer: \"{text}\"");
            }
            else
            {
                Console.WriteLine("No hay nada para deshacer.");
            }
        }

        public string GetText() => text;
    }

    class CopyCommand : ICommandExe
    {
        private TextEditor editor;
        public CopyCommand(TextEditor editor) => this.editor = editor;
        public void Execute() => editor.Copy();
    }

    class PasteCommand : ICommandExe
    {
        private TextEditor editor;
        public PasteCommand(TextEditor editor) => this.editor = editor;
        public void Execute() => editor.Paste();
    }

    class UndoCommand : ICommandExe
    {
        private TextEditor editor;
        public UndoCommand(TextEditor editor) => this.editor = editor;
        public void Execute() => editor.Undo();
    }

    class Toolbar
    {
        private Dictionary<string, ICommandExe> commands = new();

        public void SetCommand(string button, ICommandExe command)
        {
            commands[button] = command;
        }

        public void ClickButton(string button)
        {
            if (commands.ContainsKey(button))
            {
                commands[button].Execute();
            }
            else
            {
                Console.WriteLine($"No hay un comando asignado al botón \"{button}\"");
            }
        }
    }

    public static class Command_2
    {
        public static void Main()
        {
            var editor = new TextEditor();
            var toolbar = new Toolbar();

            toolbar.SetCommand("copy", new CopyCommand(editor));
            toolbar.SetCommand("paste", new PasteCommand(editor));
            toolbar.SetCommand("undo", new UndoCommand(editor));

            foreach (char c in "Hola Mundo!2")
            {
                editor.Type(c);
            }

            Console.WriteLine($"Texto actual: \"{editor.GetText()}\"");

            Console.WriteLine("\nCopiando texto:");
            toolbar.ClickButton("copy");

            Console.WriteLine("\nPegando texto:");
            toolbar.ClickButton("paste");

            Console.WriteLine("\nDeshaciendo la última acción:");
            toolbar.ClickButton("undo");

            Console.WriteLine("\nDeshaciendo de nuevo:");
            toolbar.ClickButton("undo");

            Console.WriteLine($"\nTexto final: \"{editor.GetText()}\"");
        }
    }

}
