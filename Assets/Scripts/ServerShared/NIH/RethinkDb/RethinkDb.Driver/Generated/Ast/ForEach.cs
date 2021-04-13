














//AUTOGENERATED, DO NOTMODIFY.
//Do not edit this file directly.

#pragma warning disable 1591 // Missing XML comment for publicly visible type or member
// ReSharper disable CheckNamespace

using System;
using RethinkDb.Driver.Ast;
using RethinkDb.Driver.Model;
using RethinkDb.Driver.Proto;
using System.Collections;
using System.Collections.Generic;


namespace RethinkDb.Driver.Ast {

    public partial class ForEach : ReqlExpr {

    
    
    
/// <summary>
/// <para>Loop over a sequence, evaluating the given write query for each element.</para>
/// </summary>
/// <example><para>Example: Now that our heroes have defeated their villains, we can safely remove them from the villain table.</para>
/// <code>r.table('marvel').forEach(function(hero) {
///     return r.table('villains').get(hero('villainDefeated')).delete()
/// }).run(conn, callback)
/// </code></example>
        public ForEach (object arg) : this(new Arguments(arg), null) {
        }
/// <summary>
/// <para>Loop over a sequence, evaluating the given write query for each element.</para>
/// </summary>
/// <example><para>Example: Now that our heroes have defeated their villains, we can safely remove them from the villain table.</para>
/// <code>r.table('marvel').forEach(function(hero) {
///     return r.table('villains').get(hero('villainDefeated')).delete()
/// }).run(conn, callback)
/// </code></example>
        public ForEach (Arguments args) : this(args, null) {
        }
/// <summary>
/// <para>Loop over a sequence, evaluating the given write query for each element.</para>
/// </summary>
/// <example><para>Example: Now that our heroes have defeated their villains, we can safely remove them from the villain table.</para>
/// <code>r.table('marvel').forEach(function(hero) {
///     return r.table('villains').get(hero('villainDefeated')).delete()
/// }).run(conn, callback)
/// </code></example>
        public ForEach (Arguments args, OptArgs optargs)
         : base(TermType.FOR_EACH, args, optargs) {
        }


    



    


    

    
        /// <summary>
        /// Get a single field from an object. If called on a sequence, gets that field from every object in the sequence, skipping objects that lack it.
        /// </summary>
        /// <param name="bracket"></param>
        public new Bracket this[string bracket] => base[bracket];
        
        /// <summary>
        /// Get the nth element of a sequence, counting from zero. If the argument is negative, count from the last element.
        /// </summary>
        /// <param name="bracket"></param>
        /// <returns></returns>
        public new Bracket this[int bracket] => base[bracket];


    

    


    
    }
}