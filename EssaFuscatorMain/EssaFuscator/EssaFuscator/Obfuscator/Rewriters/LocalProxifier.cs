using System;
using System.Collections.Generic;
using Loretta.CodeAnalysis;
using Loretta.CodeAnalysis.Lua;
using Loretta.CodeAnalysis.Lua.Syntax;

namespace EssaFuscator.Obfuscator.Rewriters;

public class LocalProfixier : LuaSyntaxRewriter
{
    private static string RandomString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        var stringChars = new char[8];
        var random = new Random();

        for (var i = 0; i < stringChars.Length; i++)
            stringChars[i] = chars[random.Next(chars.Length)];

        return new string(stringChars);
    }

    private ExpressionSyntax GetProxy(ExpressionSyntax expression, bool? dontcare = false)
    {
        var index = new Random().Next(1, 4);

        ExpressionSyntax realBranch = null!;
        ExpressionSyntax fakeBranch;

        var explist = SyntaxFactory.SeparatedList<ExpressionSyntax>();
        explist = explist.Add(expression);
        var list = SyntaxFactory.List<StatementSyntax>();
        list = list.Add(SyntaxFactory.ReturnStatement(explist));
        var seplist = SyntaxFactory.SeparatedList<ExpressionSyntax>();
        seplist = seplist.Add(SyntaxFactory.AnonymousFunctionExpression(
            null, SyntaxFactory.ParameterList(), null, SyntaxFactory.StatementList(list)
        ));
        
        var topLevel = new Random().Next(1, 5) == 4 ? GetProxy(SyntaxFactory.FunctionCallExpression(SyntaxFactory.FunctionCallExpression(SyntaxFactory.IdentifierName("__Wrap__"),
            SyntaxFactory.ExpressionListFunctionArgument(seplist)), SyntaxFactory.ExpressionListFunctionArgument())) : SyntaxFactory.FunctionCallExpression(SyntaxFactory.FunctionCallExpression(SyntaxFactory.IdentifierName("__Wrap__"),
            SyntaxFactory.ExpressionListFunctionArgument(seplist)), SyntaxFactory.ExpressionListFunctionArgument());

        var fakeLevels = new List<ExpressionSyntax>();
        
        for (var i = 0; i < new Random().Next(1, 2); i++)
        {
            var dlist = SyntaxFactory.SeparatedList<ExpressionSyntax>();

            var rexplist = SyntaxFactory.SeparatedList<ExpressionSyntax>();
            rexplist = rexplist.Add(topLevel);
            var rlist = SyntaxFactory.List<StatementSyntax>();
            rlist = rlist.Add(SyntaxFactory.ReturnStatement(rexplist));
            
            dlist = dlist.Add(SyntaxFactory.AnonymousFunctionExpression(null, SyntaxFactory.ParameterList(), null, SyntaxFactory.StatementList(rlist)));
            topLevel = SyntaxFactory.FunctionCallExpression(SyntaxFactory.FunctionCallExpression(SyntaxFactory.IdentifierName("__Wrap__"),
                SyntaxFactory.ExpressionListFunctionArgument(dlist)), SyntaxFactory.ExpressionListFunctionArgument());
        }

        var fakeLevelsn = new Random().Next(1, 3);
        for (var i = 0; i < index + fakeLevelsn; i++)
        {
            var fexplist = SyntaxFactory.SeparatedList<ExpressionSyntax>();
            fexplist = fexplist.Add(SyntaxFactory.IdentifierName(RandomString()));
            var flist = SyntaxFactory.List<StatementSyntax>();
            flist = flist.Add(SyntaxFactory.ReturnStatement(fexplist));
            var fseplist = SyntaxFactory.SeparatedList<ExpressionSyntax>();
            fseplist = fseplist.Add(SyntaxFactory.AnonymousFunctionExpression(
                null, SyntaxFactory.ParameterList(), null, SyntaxFactory.StatementList(flist)
            ));
            
            var aspirin = SyntaxFactory.FunctionCallExpression(SyntaxFactory.FunctionCallExpression(
                        SyntaxFactory.IdentifierName("__Wrap__"),
                        SyntaxFactory.ExpressionListFunctionArgument(fseplist)),
                    SyntaxFactory.ExpressionListFunctionArgument());
            
            fakeLevels.Add(aspirin);
        }

        var arglist = SyntaxFactory.SeparatedList<ExpressionSyntax>();
        arglist = arglist.Add(SyntaxFactory.ParseExpression(index.ToString()));
        for (var i = 1; i < index + fakeLevelsn; i++)
        {
            if (index == i)
            {
                arglist = arglist.Add(topLevel);
            }
            else
            {
              arglist = arglist.Add(SyntaxFactory.IdentifierName(RandomString()));
            }
        }
        
        var ok = SyntaxFactory.FunctionCallExpression(SyntaxFactory.IdentifierName("__Select__"), SyntaxFactory.ExpressionListFunctionArgument(arglist));
        return ok.NormalizeWhitespace();
    }

    public override SyntaxNode? VisitLiteralExpression(LiteralExpressionSyntax node)
    {
        var proxy = GetProxy(node);
        return proxy.ToFullString().Contains("...") ? base.VisitLiteralExpression(node) : proxy;
    }

    public override SyntaxNode? VisitBinaryExpression(BinaryExpressionSyntax node)
    {
        var proxy = GetProxy(node);
        return proxy.ToFullString().Contains("...") ? base.VisitBinaryExpression(node) : proxy;
    }

    public override SyntaxNode? VisitFunctionCallExpression(FunctionCallExpressionSyntax node)
    {
        if (node.Expression is IdentifierNameSyntax {Name: "pairs"}) return base.VisitFunctionCallExpression(node);
        
        var proxy = GetProxy(node);
        return proxy.ToFullString().Contains("...") ? base.VisitFunctionCallExpression(node) : proxy;
    }

    public override SyntaxNode? VisitTableConstructorExpression(TableConstructorExpressionSyntax node)
    {
        var proxy = GetProxy(node);
        return proxy.ToFullString().Contains("...") ? base.VisitTableConstructorExpression(node) : proxy;
    }
}