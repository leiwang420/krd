using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

public class SmallXmlParser
{
    [CompilerGenerated]
    private static Dictionary<string, int> switchmapD;
    private AttrListImpl attributes;
    private StringBuilder buffer;
    private int column;
    private Stack elementNames;
    private IContentHandler handler;
    private bool isWhitespace;
    private int line;
    private char[] nameBuffer;
    private TextReader reader;
    private bool resetColumn;
    private string xmlSpace;
    private Stack xmlSpaces;

    public SmallXmlParser()
    {
        this.elementNames = new Stack();
        this.xmlSpaces = new Stack();
        this.buffer = new StringBuilder(200);
        this.nameBuffer = new char[30];
        this.attributes = new AttrListImpl();
        this.line = 1;
        base..ctor();
        return;
    }

    private void Cleanup()
    {
        this.line = 1;
        this.column = 0;
        this.handler = null;
        this.reader = null;
        this.elementNames.Clear();
        this.xmlSpaces.Clear();
        this.attributes.Clear();
        this.buffer.Length = 0;
        this.xmlSpace = null;
        this.isWhitespace = 0;
        return;
    }

    private Exception Error(string msg)
    {
        return new SmallXmlParserException(msg, this.line, this.column);
    }

    public void Expect(int c)
    {
        int num;
        num = this.Read();
        if (num >= 0)
        {
            goto Label_0015;
        }
        throw this.UnexpectedEndError();
    Label_0015:
        if (num == c)
        {
            goto Label_003B;
        }
        throw this.Error(string.Format("Expected '{0}' but got {1}", (char) ((ushort) c), (char) ((ushort) num)));
    Label_003B:
        return;
    }

    private void HandleBufferedContent()
    {
        if (this.buffer.Length != null)
        {
            goto Label_0011;
        }
        return;
    Label_0011:
        if (this.isWhitespace == null)
        {
            goto Label_0037;
        }
        this.handler.OnIgnorableWhitespace(this.buffer.ToString());
        goto Label_004D;
    Label_0037:
        this.handler.OnChars(this.buffer.ToString());
    Label_004D:
        this.buffer.Length = 0;
        this.isWhitespace = 0;
        return;
    }

    private void HandleWhitespaces()
    {
        goto Label_0018;
    Label_0005:
        this.buffer.Append((ushort) this.Read());
    Label_0018:
        if (this.IsWhitespace(this.Peek()) != null)
        {
            goto Label_0005;
        }
        if (this.Peek() == 60)
        {
            goto Label_0049;
        }
        if (this.Peek() < 0)
        {
            goto Label_0049;
        }
        this.isWhitespace = 0;
    Label_0049:
        return;
    }

    private bool IsNameChar(char c, bool start)
    {
        char ch;
        UnicodeCategory category;
        ch = c;
        if (ch == 0x2d)
        {
            goto Label_0029;
        }
        if (ch == 0x2e)
        {
            goto Label_0029;
        }
        if (ch == 0x3a)
        {
            goto Label_0027;
        }
        if (ch == 0x5f)
        {
            goto Label_0027;
        }
        goto Label_002E;
    Label_0027:
        return 1;
    Label_0029:
        return (start == 0);
    Label_002E:
        if (c <= 0x100)
        {
            goto Label_007B;
        }
        ch = c;
        if (ch == 0x6e5)
        {
            goto Label_0061;
        }
        if (ch == 0x6e6)
        {
            goto Label_0061;
        }
        if (ch == 0x559)
        {
            goto Label_0061;
        }
        goto Label_0063;
    Label_0061:
        return 1;
    Label_0063:
        if (0x2bb > c)
        {
            goto Label_007B;
        }
        if (c > 0x2c1)
        {
            goto Label_007B;
        }
        return 1;
    Label_007B:
        switch (char.GetUnicodeCategory(c))
        {
            case 0:
                goto Label_00B5;

            case 1:
                goto Label_00B5;

            case 2:
                goto Label_00B5;

            case 3:
                goto Label_00B7;

            case 4:
                goto Label_00B5;

            case 5:
                goto Label_00B7;

            case 6:
                goto Label_00B7;

            case 7:
                goto Label_00B7;

            case 8:
                goto Label_00B7;

            case 9:
                goto Label_00B5;
        }
        goto Label_00BC;
    Label_00B5:
        return 1;
    Label_00B7:
        return (start == 0);
    Label_00BC:
        return 0;
    }

    private bool IsWhitespace(int c)
    {
        int num;
        num = c;
        switch ((num - 9))
        {
            case 0:
                goto Label_002C;

            case 1:
                goto Label_002C;

            case 2:
                goto Label_001F;

            case 3:
                goto Label_001F;

            case 4:
                goto Label_002C;
        }
    Label_001F:
        if (num == 0x20)
        {
            goto Label_002C;
        }
        goto Label_002E;
    Label_002C:
        return 1;
    Label_002E:
        return 0;
    }

    public void Parse(TextReader input, IContentHandler handler)
    {
        this.reader = input;
        this.handler = handler;
        handler.OnStartParsing(this);
        goto Label_0020;
    Label_001A:
        this.ReadContent();
    Label_0020:
        if (this.Peek() >= 0)
        {
            goto Label_001A;
        }
        this.HandleBufferedContent();
        if (this.elementNames.Count <= 0)
        {
            goto Label_005F;
        }
        throw this.Error(string.Format("Insufficient close tag: {0}", this.elementNames.Peek()));
    Label_005F:
        handler.OnEndParsing(this);
        this.Cleanup();
        return;
    }

    private int Peek()
    {
        return this.reader.Peek();
    }

    private int Read()
    {
        int num;
        num = this.reader.Read();
        if (num != 10)
        {
            goto Label_001B;
        }
        this.resetColumn = 1;
    Label_001B:
        if (this.resetColumn == null)
        {
            goto Label_0047;
        }
        this.line += 1;
        this.resetColumn = 0;
        this.column = 1;
        goto Label_0055;
    Label_0047:
        this.column += 1;
    Label_0055:
        return num;
    }

    private void ReadAttribute(AttrListImpl a)
    {
        string str;
        string str2;
        int num;
        this.SkipWhitespaces(1);
        if (this.Peek() == 0x2f)
        {
            goto Label_0021;
        }
        if (this.Peek() != 0x3e)
        {
            goto Label_0022;
        }
    Label_0021:
        return;
    Label_0022:
        str = this.ReadName();
        this.SkipWhitespaces();
        this.Expect(0x3d);
        this.SkipWhitespaces();
        num = this.Read();
        if (num == 0x22)
        {
            goto Label_0068;
        }
        if (num == 0x27)
        {
            goto Label_0059;
        }
        goto Label_0077;
    Label_0059:
        str2 = this.ReadUntil(0x27, 1);
        goto Label_0083;
    Label_0068:
        str2 = this.ReadUntil(0x22, 1);
        goto Label_0083;
    Label_0077:
        throw this.Error("Invalid attribute value markup.");
    Label_0083:
        if ((str == "xml:space") == null)
        {
            goto Label_009A;
        }
        this.xmlSpace = str2;
    Label_009A:
        a.Add(str, str2);
        return;
    }

    private void ReadCDATASection()
    {
        int num;
        char ch;
        int num2;
        int num3;
        num = 0;
    Label_0002:
        if (this.Peek() >= 0)
        {
            goto Label_0015;
        }
        throw this.UnexpectedEndError();
    Label_0015:
        ch = (ushort) this.Read();
        if (ch != 0x5d)
        {
            goto Label_002E;
        }
        num += 1;
        goto Label_0091;
    Label_002E:
        if (ch != 0x3e)
        {
            goto Label_0062;
        }
        if (num <= 1)
        {
            goto Label_0062;
        }
        num2 = num;
        goto Label_0056;
    Label_0044:
        this.buffer.Append(0x5d);
        num2 -= 1;
    Label_0056:
        if (num2 > 2)
        {
            goto Label_0044;
        }
        goto Label_0096;
    Label_0062:
        num3 = 0;
        goto Label_007B;
    Label_0069:
        this.buffer.Append(0x5d);
        num3 += 1;
    Label_007B:
        if (num3 < num)
        {
            goto Label_0069;
        }
        num = 0;
        this.buffer.Append(ch);
    Label_0091:
        goto Label_0002;
    Label_0096:
        return;
    }

    private int ReadCharacterReference()
    {
        int num;
        int num2;
        int num3;
        num = 0;
        if (this.Peek() != 120)
        {
            goto Label_00AA;
        }
        this.Read();
        num2 = this.Peek();
        goto Label_009E;
    Label_0022:
        if (0x30 > num2)
        {
            goto Label_0043;
        }
        if (num2 > 0x39)
        {
            goto Label_0043;
        }
        num = num << (((4 + num2) - 0x30) & 0x1f);
        goto Label_0090;
    Label_0043:
        if (0x41 > num2)
        {
            goto Label_0067;
        }
        if (num2 > 70)
        {
            goto Label_0067;
        }
        num = num << ((((4 + num2) - 0x41) + 10) & 0x1f);
        goto Label_0090;
    Label_0067:
        if (0x61 > num2)
        {
            goto Label_00F1;
        }
        if (num2 > 0x66)
        {
            goto Label_00F1;
        }
        num = num << ((((4 + num2) - 0x61) + 10) & 0x1f);
        goto Label_0090;
        goto Label_00A5;
    Label_0090:
        this.Read();
        num2 = this.Peek();
    Label_009E:
        if (num2 >= 0)
        {
            goto Label_0022;
        }
    Label_00A5:
        goto Label_00F1;
    Label_00AA:
        num3 = this.Peek();
        goto Label_00EA;
    Label_00B6:
        if (0x30 > num3)
        {
            goto Label_00F1;
        }
        if (num3 > 0x39)
        {
            goto Label_00F1;
        }
        num = num << (((4 + num3) - 0x30) & 0x1f);
        goto Label_00DC;
        goto Label_00F1;
    Label_00DC:
        this.Read();
        num3 = this.Peek();
    Label_00EA:
        if (num3 >= 0)
        {
            goto Label_00B6;
        }
    Label_00F1:
        return num;
    }

    private void ReadCharacters()
    {
        int num;
        int num2;
        this.isWhitespace = 0;
    Label_0007:
        num2 = this.Peek();
        if (num2 == -1)
        {
            goto Label_002C;
        }
        if (num2 == 0x26)
        {
            goto Label_002E;
        }
        if (num2 == 60)
        {
            goto Label_002D;
        }
        goto Label_0040;
    Label_002C:
        return;
    Label_002D:
        return;
    Label_002E:
        this.Read();
        this.ReadReference();
        goto Label_0007;
    Label_0040:
        this.buffer.Append((ushort) this.Read());
        goto Label_0007;
        goto Label_0007;
    }

    private void ReadComment()
    {
        this.Expect(0x2d);
        this.Expect(0x2d);
    Label_0010:
        if (this.Read() == 0x2d)
        {
            goto Label_0022;
        }
        goto Label_0010;
    Label_0022:
        if (this.Read() == 0x2d)
        {
            goto Label_0034;
        }
        goto Label_0010;
    Label_0034:
        if (this.Read() == 0x3e)
        {
            goto Label_0057;
        }
        throw this.Error("'--' is not allowed inside comment markup.");
        goto Label_0057;
        goto Label_0010;
    Label_0057:
        return;
    }

    public void ReadContent()
    {
        string str;
        string str2;
        string str3;
        int num;
        if (this.IsWhitespace(this.Peek()) == null)
        {
            goto Label_002E;
        }
        if (this.buffer.Length != null)
        {
            goto Label_0028;
        }
        this.isWhitespace = 1;
    Label_0028:
        this.HandleWhitespaces();
    Label_002E:
        if (this.Peek() != 60)
        {
            goto Label_02C3;
        }
        this.Read();
        num = this.Peek();
        if (num == 0x21)
        {
            goto Label_0066;
        }
        if (num == 0x2f)
        {
            goto Label_0168;
        }
        if (num == 0x3f)
        {
            goto Label_00F2;
        }
        goto Label_021D;
    Label_0066:
        this.Read();
        if (this.Peek() != 0x5b)
        {
            goto Label_00B1;
        }
        this.Read();
        if ((this.ReadName() != "CDATA") == null)
        {
            goto Label_00A2;
        }
        throw this.Error("Invalid declaration markup");
    Label_00A2:
        this.Expect(0x5b);
        this.ReadCDATASection();
        return;
    Label_00B1:
        if (this.Peek() != 0x2d)
        {
            goto Label_00C5;
        }
        this.ReadComment();
        return;
    Label_00C5:
        if ((this.ReadName() != "DOCTYPE") == null)
        {
            goto Label_00E6;
        }
        throw this.Error("Invalid declaration markup.");
    Label_00E6:
        throw this.Error("This parser does not support document type.");
    Label_00F2:
        this.HandleBufferedContent();
        this.Read();
        str = this.ReadName();
        this.SkipWhitespaces();
        str2 = string.Empty;
        if (this.Peek() == 0x3f)
        {
            goto Label_0152;
        }
    Label_011F:
        str2 = str2 + this.ReadUntil(0x3f, 0);
        if (this.Peek() != 0x3e)
        {
            goto Label_0141;
        }
        goto Label_0152;
    Label_0141:
        str2 = str2 + "?";
        goto Label_011F;
    Label_0152:
        this.handler.OnProcessingInstruction(str, str2);
        this.Expect(0x3e);
        return;
    Label_0168:
        this.HandleBufferedContent();
        if (this.elementNames.Count != null)
        {
            goto Label_0185;
        }
        throw this.UnexpectedEndError();
    Label_0185:
        this.Read();
        str = this.ReadName();
        this.SkipWhitespaces();
        str3 = (string) this.elementNames.Pop();
        this.xmlSpaces.Pop();
        if (this.xmlSpaces.Count <= 0)
        {
            goto Label_01E2;
        }
        this.xmlSpace = (string) this.xmlSpaces.Peek();
        goto Label_01E9;
    Label_01E2:
        this.xmlSpace = null;
    Label_01E9:
        if ((str != str3) == null)
        {
            goto Label_0208;
        }
        throw this.Error(string.Format("End tag mismatch: expected {0} but found {1}", str3, str));
    Label_0208:
        this.handler.OnEndElement(str);
        this.Expect(0x3e);
        return;
    Label_021D:
        this.HandleBufferedContent();
        str = this.ReadName();
        goto Label_023B;
    Label_022F:
        this.ReadAttribute(this.attributes);
    Label_023B:
        if (this.Peek() == 0x3e)
        {
            goto Label_0255;
        }
        if (this.Peek() != 0x2f)
        {
            goto Label_022F;
        }
    Label_0255:
        this.handler.OnStartElement(str, this.attributes);
        this.attributes.Clear();
        this.SkipWhitespaces();
        if (this.Peek() != 0x2f)
        {
            goto Label_029D;
        }
        this.Read();
        this.handler.OnEndElement(str);
        goto Label_02BA;
    Label_029D:
        this.elementNames.Push(str);
        this.xmlSpaces.Push(this.xmlSpace);
    Label_02BA:
        this.Expect(0x3e);
        return;
    Label_02C3:
        this.ReadCharacters();
        return;
    }

    public string ReadName()
    {
        int num;
        int num2;
        char ch;
        char[] chArray;
        num = 0;
        if (this.Peek() < 0)
        {
            goto Label_0021;
        }
        if (this.IsNameChar((ushort) this.Peek(), 1) != null)
        {
            goto Label_002D;
        }
    Label_0021:
        throw this.Error("XML name start character is expected.");
    Label_002D:
        num2 = this.Peek();
        goto Label_0096;
    Label_0039:
        ch = (ushort) num2;
        if (this.IsNameChar(ch, 0) != null)
        {
            goto Label_004E;
        }
        goto Label_009D;
    Label_004E:
        if (num != ((int) this.nameBuffer.Length))
        {
            goto Label_007B;
        }
        chArray = new char[num * 2];
        Array.Copy(this.nameBuffer, 0, chArray, 0, num);
        this.nameBuffer = chArray;
    Label_007B:
        this.nameBuffer[num++] = ch;
        this.Read();
        num2 = this.Peek();
    Label_0096:
        if (num2 >= 0)
        {
            goto Label_0039;
        }
    Label_009D:
        if (num != null)
        {
            goto Label_00AF;
        }
        throw this.Error("Valid XML name is expected.");
    Label_00AF:
        return new string(this.nameBuffer, 0, num);
    }

    private unsafe void ReadReference()
    {
        string str;
        string str2;
        Dictionary<string, int> dictionary;
        int num;
        if (this.Peek() != 0x23)
        {
            goto Label_0020;
        }
        this.Read();
        this.ReadCharacterReference();
        goto Label_0126;
    Label_0020:
        str = this.ReadName();
        this.Expect(0x3b);
        str2 = str;
        if (str2 == null)
        {
            goto Label_011A;
        }
        if (switchmapD != null)
        {
            goto Label_008A;
        }
        dictionary = new Dictionary<string, int>(5);
        dictionary.Add("amp", 0);
        dictionary.Add("quot", 1);
        dictionary.Add("apos", 2);
        dictionary.Add("lt", 3);
        dictionary.Add("gt", 4);
        switchmapD = dictionary;
    Label_008A:
        if (switchmapD.TryGetValue(str2, &num) == null)
        {
            goto Label_011A;
        }
        switch (num)
        {
            case 0:
                goto Label_00BB;

            case 1:
                goto Label_00CE;

            case 2:
                goto Label_00E1;

            case 3:
                goto Label_00F4;

            case 4:
                goto Label_0107;
        }
        goto Label_011A;
    Label_00BB:
        this.buffer.Append(0x26);
        goto Label_0126;
    Label_00CE:
        this.buffer.Append(0x22);
        goto Label_0126;
    Label_00E1:
        this.buffer.Append(0x27);
        goto Label_0126;
    Label_00F4:
        this.buffer.Append(60);
        goto Label_0126;
    Label_0107:
        this.buffer.Append(0x3e);
        goto Label_0126;
    Label_011A:
        throw this.Error("General non-predefined entity reference is not supported in this parser.");
    Label_0126:
        return;
    }

    private string ReadUntil(char until, bool handleReferences)
    {
        char ch;
        string str;
    Label_0000:
        if (this.Peek() >= 0)
        {
            goto Label_0013;
        }
        throw this.UnexpectedEndError();
    Label_0013:
        ch = (ushort) this.Read();
        if (ch != until)
        {
            goto Label_0027;
        }
        goto Label_0052;
    Label_0027:
        if (handleReferences == null)
        {
            goto Label_0040;
        }
        if (ch != 0x26)
        {
            goto Label_0040;
        }
        this.ReadReference();
        goto Label_004D;
    Label_0040:
        this.buffer.Append(ch);
    Label_004D:
        goto Label_0000;
    Label_0052:
        str = this.buffer.ToString();
        this.buffer.Length = 0;
        return str;
    }

    public void SkipWhitespaces()
    {
        this.SkipWhitespaces(0);
        return;
    }

    public void SkipWhitespaces(bool expected)
    {
        int num;
    Label_0000:
        num = this.Peek();
        switch ((num - 9))
        {
            case 0:
                goto Label_0031;

            case 1:
                goto Label_0031;

            case 2:
                goto Label_0024;

            case 3:
                goto Label_0024;

            case 4:
                goto Label_0031;
        }
    Label_0024:
        if (num == 0x20)
        {
            goto Label_0031;
        }
        goto Label_0046;
    Label_0031:
        this.Read();
        if (expected == null)
        {
            goto Label_0000;
        }
        expected = 0;
        goto Label_0000;
    Label_0046:
        if (expected == null)
        {
            goto Label_0058;
        }
        throw this.Error("Whitespace is expected.");
    Label_0058:
        return;
        goto Label_0000;
    }

    private Exception UnexpectedEndError()
    {
        string[] strArray;
        strArray = new string[this.elementNames.Count];
        this.elementNames.CopyTo(strArray, 0);
        return this.Error(string.Format("Unexpected end of stream. Element stack content is {0}", string.Join(",", strArray)));
    }

    private class AttrListImpl : SmallXmlParser.IAttrList
    {
        private ArrayList attrNames;
        private ArrayList attrValues;

        public AttrListImpl()
        {
            this.attrNames = new ArrayList();
            this.attrValues = new ArrayList();
            base..ctor();
            return;
        }

        internal void Add(string name, string value)
        {
            this.attrNames.Add(name);
            this.attrValues.Add(value);
            return;
        }

        internal void Clear()
        {
            this.attrNames.Clear();
            this.attrValues.Clear();
            return;
        }

        public string GetName(int i)
        {
            return (string) this.attrNames[i];
        }

        public string GetValue(int i)
        {
            return (string) this.attrValues[i];
        }

        public string GetValue(string name)
        {
            int num;
            num = 0;
            goto Label_0039;
        Label_0007:
            if ((((string) this.attrNames[num]) == name) == null)
            {
                goto Label_0035;
            }
            return (string) this.attrValues[num];
        Label_0035:
            num += 1;
        Label_0039:
            if (num < this.attrNames.Count)
            {
                goto Label_0007;
            }
            return null;
        }

        public bool IsEmpty
        {
            get
            {
                return (this.attrNames.Count == 0);
            }
        }

        public int Length
        {
            get
            {
                return this.attrNames.Count;
            }
        }

        public string[] Names
        {
            get
            {
                return (string[]) this.attrNames.ToArray(typeof(string));
            }
        }

        public string[] Values
        {
            get
            {
                return (string[]) this.attrValues.ToArray(typeof(string));
            }
        }
    }

    public interface IAttrList
    {
        string GetName(int i);
        string GetValue(int i);
        string GetValue(string name);

        bool IsEmpty { get; }

        int Length { get; }

        string[] Names { get; }

        string[] Values { get; }
    }

    public interface IContentHandler
    {
        void OnChars(string text);
        void OnEndElement(string name);
        void OnEndParsing(SmallXmlParser parser);
        void OnIgnorableWhitespace(string text);
        void OnProcessingInstruction(string name, string text);
        void OnStartElement(string name, SmallXmlParser.IAttrList attrs);
        void OnStartParsing(SmallXmlParser parser);
    }
}

