using System;
using System.Text;
using System.Text.Unicode;
using Loretta.CodeAnalysis;
using Loretta.CodeAnalysis.Lua;
using Loretta.CodeAnalysis.Lua.Syntax;

namespace EssaFuscator.Obfuscator.Rewriters;

public class StringEncryption : LuaSyntaxRewriter
{
    public readonly int EncryptionKey;
    
    public StringEncryption()
    {
        EncryptionKey = new Random().Next(1, 255);
    }
    
    private (int, int, int, int) EncryptedTuple(int constant)
    {
        var (b0, b1, b2, b3) = (0,0,0,0);
        
        constant ^= EncryptionKey;
        b3 = constant & 0xff;
        constant >>= 8;
        b2 = constant & 0xff;
        constant >>= 8;
        b1 = constant & 0xff;
        constant >>= 8;
        b0 = constant & 0xff;

        return (b0, b1, b2, b3);
    }
    
    public override SyntaxNode? VisitLiteralExpression(LiteralExpressionSyntax node)
    {
        if (node.Kind() != SyntaxKind.StringLiteralExpression || node.Parent is FunctionCallExpressionSyntax) return base.VisitLiteralExpression(node);

        var expressionFields = SyntaxFactory.SeparatedList<TableFieldSyntax>();

        var bytes = Encoding.UTF8.GetBytes((string) node.Token.Value!);

        foreach (var bit in bytes)
        {
            var (b0, b1, b2, b3) = EncryptedTuple(bit);

            expressionFields = expressionFields.Add(SyntaxFactory.UnkeyedTableField(SyntaxFactory.ParseExpression($"{{{b0}, {b1}, {b2}, {b3}}}"))); 
        }

        var list = SyntaxFactory.SeparatedList<ExpressionSyntax>();
        list = list.Add(SyntaxFactory.TableConstructorExpression(expressionFields));
        
        return SyntaxFactory.FunctionCallExpression(SyntaxFactory.IdentifierName("__DecryptString__"), SyntaxFactory.ExpressionListFunctionArgument(list));
    }
}