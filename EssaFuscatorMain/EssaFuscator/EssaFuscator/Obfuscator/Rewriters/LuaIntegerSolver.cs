using System;
using Loretta.CodeAnalysis;
using Loretta.CodeAnalysis.Lua;
using Loretta.CodeAnalysis.Lua.Syntax;

namespace EssaFuscator.Obfuscator.Rewriters;

public class LuaIntegerSolver : LuaSyntaxRewriter
{
    public override SyntaxNode? VisitLiteralExpression(LiteralExpressionSyntax node)
    {
        if (node.Kind() != SyntaxKind.NumericalLiteralExpression) return base.VisitLiteralExpression(node);

        if (node.Token.Value is long num)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return SyntaxFactory.BinaryExpression(SyntaxKind.ExclusiveOrExpression, node, SyntaxFactory.Token(SyntaxKind.PipeToken), SyntaxFactory.LiteralExpression(SyntaxKind.NumericalLiteralExpression, SyntaxFactory.Literal(1)));
        }
        
        return base.VisitLiteralExpression(node);
    }
}