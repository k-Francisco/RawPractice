/* Copyright (C) Ion OÜ - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Mihhail Maslakov <mihhail.maslakov@gmail.com>, July 2017
 */
#pragma warning disable
namespace XamarinFormsLive { 
using System;using System.Collections.Generic;using System.Diagnostics;using
System.Linq;using System.Reflection;using System.Text;using System.Threading.
Tasks;using Xamarin.Forms;using Xamarin.Forms.Xaml;using Xamarin.Forms.Xaml.
Internals;using Xamarin.Forms.Internals;using System.Threading;class C{private
string[]n;private int o;public C(string[]a){if(a.Length==0)throw new
InvalidOperationException(
"Can't initialize circular buffer with an empty collection");n=a;}public string
Get(){return n[o++%n.Length];}}class D{public static void WriteLine(string a){
Debug.WriteLine("XL: "+a);}public static void Exception(Exception a){if(a is
TargetInvocationException){var b=(TargetInvocationException)a;Debug.WriteLine(
"XL: "+b.InnerException.Message);}else{Debug.WriteLine("XL: "+a.Message);}}
internal static void n(string a){Debug.WriteLine("XL: "+a);}}public static class
KnownTypes{private static readonly Dictionary<string,Type>n=new Dictionary<
string,Type>();private static readonly Assembly[]o;static KnownTypes(){try{o=r()
;}catch{D.n("Failed to load assemblies");o=new Assembly[]{typeof(Element).
GetTypeInfo().Assembly,typeof(string).GetTypeInfo().Assembly};}}public static
Tuple<Type,FieldInfo>FindShortTypeWithProperty(string a,string b){p();foreach(
var kvp in n){if(kvp.Key.EndsWith("."+a)){var c=FindBindablePropertyField(kvp.
Value,b);if(c!=null)return Tuple.Create(kvp.Value,c);}}return null;}public
static Type FindType(string a){p();Type b;if(n.TryGetValue(a,out b))return b;
return q(a);}private static void p(){if(n.Count==0){var a=o.Where(b=>b!=null).
SelectMany(b=>b.DefinedTypes);foreach(var type in a)n[type.FullName]=type.AsType
();}}private static Type q(string a){var b=new[]{
"System.Net.Sockets, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
,
"System.Net.Sockets, Version=4.3.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
,
"System.Net.Primitives, Version=4.0.11.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
,
"System.Net.Primitives, Version=4.3.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
,
"System.Net.Primitives, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
,};if(string.IsNullOrWhiteSpace(a))throw new InvalidOperationException(
"Type name shouldn't be empty or null");if(a.StartsWith("System.Net",
StringComparison.OrdinalIgnoreCase)){foreach(var netAssembly in b){try{var c=
Type.GetType(a+", "+netAssembly);if(c!=null)return c;}catch{}}}return null;}
public static FieldInfo FindBindablePropertyField(Type a,string b){var c=a.
GetTypeInfo();foreach(var declaredField in c.DeclaredFields)if(declaredField.
IsStatic&&declaredField.Name==b+"Property")return declaredField;if(c.BaseType==
null)return null;return FindBindablePropertyField(c.BaseType,b);}public static
ConstructorInfo GetConstructor(Type a,params Type[]b){var c=a.GetConstructors().
FirstOrDefault(d=>{var f=d.GetParameters();var g=f.Length;return g==b.Length&&f.
Zip(b,(h,i)=>h.ParameterType.IsAssignableFrom(i)).All(j=>j);});if(c==null)throw
new InvalidOperationException("Couldn't find constructor for "+a+
" with parameters: "+string.Join(", ",b.Select(k=>k.Name)));return c;}private
static Assembly[]r(){var a=typeof(string).GetTypeInfo();var b=a.Assembly;var c=b
.GetType("System.AppDomain");var d=c.GetRuntimeProperty("CurrentDomain");var f=d
.GetMethod;var g=f.Invoke(null,new object[]{});var h=g.GetType().
GetRuntimeMethod("GetAssemblies",new Type[]{});return h.Invoke(g,new object[]{})
as Assembly[];}}class E{private static E n;public static E Instance{get{return n
??(n=new E());}}private readonly ListenerParser o=new ListenerParser();private
readonly byte[]p=new byte[1024*100];private readonly G q;private const int r=
53030;private const int s=53050;private string t;private SocketProxy u;private E
(){D.WriteLine("Listener ctor");o.MessageReceived+=B;if(Device.OS==
TargetPlatform.Android){q=new G(new[]{"169.254.80.80","10.0.2.2","10.0.3.2"},w,v
);}else if(Device.OS==TargetPlatform.iOS){q=new G(new[]{"127.0.0.1",
"169.254.80.80","10.0.2.2","10.0.3.2"},w,v);}else{q=new G(new[]{"127.0.0.1",
"169.254.80.80","10.0.2.2","10.0.3.2"},w,v);}}private void v(){D.n(
"Failed to find find a handshake server");D.n("Trying to use UDP connection");
var a=new J(s);a.BeginReceive(z,a);}private void w(string a){t=a;x(t);}private
void x(string a){var b=new I();try{D.n("Listener connecting to "+a);b.r(a,r).
Wait(20);D.n("Listener connected to "+a);u=b.Client;y(u,0);}catch(Exception e){D
.n("Listener failed to connect to "+a);D.Exception(e);}}private void y(
SocketProxy a,int b){try{if(b>=p.Length){b=0;}a.BeginReceive(p,b,p.Length-b,0,A,
b);}catch(Exception e){D.WriteLine("BeginReceive failed");D.Exception(e);x(t);}}
private void z(IAsyncResult a){J b=null;try{b=(J)a.AsyncState;var c=new H(
IPAddressProxy.Any,s).Object;var d=b.EndReceive(a,ref c);o.Feed(d,d.Length);b.
BeginReceive(z,b);}catch(Exception e){D.WriteLine("UdpEndReceive failed");D.
Exception(e);if(b!=null)((IDisposable)b).Dispose();b=new J(s);b.BeginReceive(z,b
);}}private void A(IAsyncResult a){try{var b=(int)a.AsyncState;var c=u.
EndReceive(a);D.WriteLine("Listener EndReceive ("+c+")");if(c==0){D.WriteLine(
"Connection to the server has ended");x(t);return;}o.Feed(p,c);y(u,0);}catch(
Exception e){D.WriteLine("EndReceive failed");D.Exception(e);x(t);}}private void
B(object a,ListenerParserEventArgs b){D.WriteLine(
"Listener ParserOnMessageReceived");var c=b.Messages;MainThread.Run(()=>{try{
RuntimeUpdateHandler.ReceiveMessages(c);}catch(Exception ex){D.WriteLine(
"ReceiveMessages failed");D.Exception(ex);}});}}public class ListenerParser{
public event EventHandler<ListenerParserEventArgs>MessageReceived;private
readonly List<byte>n=new List<byte>();private int o=0;private int p;private
string q;private int r;private byte[]s;private ushort t;private byte u;private
List<Message>v;private ushort w;private string x;private ushort y;private
DateTime z=DateTime.Now;public void Feed(byte[]a,int b){if((DateTime.Now-z).
TotalMilliseconds>3000)o=0;z=DateTime.Now;for(int c=0;c<b;c++)A(a[c]);}private
void A(byte a){switch(o){case 0:if(a==0xbe){v=new List<Message>();o=1;}break;
case 1:if(a==0xef){o=2;}break;case 2:u=a;o=3;break;case 3:n.Add(a);if(n.Count==4
){p=BitConverter.ToInt32(n.ToArray(),0);n.Clear();if(p<=0||p>10000)o=0;else o=4;
}break;case 4:n.Add(a);if(n.Count==p){q=Encoding.Unicode.GetString(n.ToArray(),0
,n.Count);n.Clear();o=5;}break;case 5:n.Add(a);if(n.Count==4){r=BitConverter.
ToInt32(n.Take(4).ToArray(),0);n.Clear();o=6;if(r<=0||r>1024*1024){o=0;}else{o=6
;}}break;case 6:n.Add(a);if(n.Count==r){var b=n.ToArray();s=b;t=Fletcher16(b);n.
Clear();o=7;}break;case 7:n.Add(a);if(n.Count==2){var c=BitConverter.ToUInt16(n.
ToArray(),0);n.Clear();if(t==c){v.Add(new Message{TargetId=q,Buffer=s});o=8;}
else o=0;}break;case 8:n.Add(a);if(n.Count==2){w=BitConverter.ToUInt16(n.ToArray
(),0);n.Clear();if(w>0)o=9;else if(u>1){u--;o=3;}else o=10;}break;case 9:n.Add(a
);if(n.Count==w){v.Last().PropertyList=Encoding.Unicode.GetString(n.ToArray(),0,
n.Count);n.Clear();if(--u>0)o=3;else o=10;}break;case 10:if(a==0xff){var d=
MessageReceived;if(d!=null){var f=x==q&&y==t;y=t;x=q;if(!f)d(this,new
ListenerParserEventArgs{Messages=v});}}o=0;break;default:throw new
ArgumentOutOfRangeException();}}public ushort Fletcher16(byte[]a){ushort b=0;
ushort c=0;for(var d=0;d<a.Length;++d){b=(ushort)((b+a[d])%255);c=(ushort)((c+b)
%255);}return(ushort)((c<<8)|b);}}public class Message{public string TargetId{
get;set;}public byte[]Buffer{get;set;}public string PropertyList{get;set;}}
public class ListenerParserEventArgs:EventArgs{public List<Message>Messages{get;
set;}}public class MainThread{public static void Run(Action a){Device.
BeginInvokeOnMainThread(a);}}public static class NumericTypes{private static
readonly HashSet<Type>n=new HashSet<Type>{typeof(int),typeof(double),typeof(
decimal),typeof(long),typeof(short),typeof(sbyte),typeof(byte),typeof(ulong),
typeof(ushort),typeof(uint),typeof(float)};private static string[]o;public
static string[]GetTypeNames(){if(o==null)o=n.Select(a=>a.FullName).ToArray();
return o;}public static bool TypeIsNumeric(Type a){return n.Contains(Nullable.
GetUnderlyingType(a)??a);}public static bool TypeIsNumeric(string a){return n.
Any(b=>b.FullName==a);}}public static class ReflectionExtensions{public static
MethodInfo GetMethod(this Type a,string b,bool c,Type[]d=null){var f=a.
GetTypeInfo().GetDeclaredMethods(b).FirstOrDefault(g=>(c?!g.IsStatic:g.IsStatic)
&&n(g,d));if(f==null)throw new Exception("Method `"+b+"` on type `"+a.Name+
"` not found");return f;}public static ConstructorInfo[]GetConstructors(this
Type a){return a.GetTypeInfo().DeclaredConstructors.ToArray();}public static
ConstructorInfo FindConstructor(this Type a,params Type[]b){return a.GetTypeInfo
().DeclaredConstructors.FirstOrDefault(c=>{var d=c.GetParameters();if(d.Length!=
b.Length)return false;return d.Zip(b,(f,g)=>f.ParameterType==g).All(h=>h);});}
public static bool IsAssignableFrom(this Type a,Type b){return a.GetTypeInfo().
IsAssignableFrom(b.GetTypeInfo());}private static bool n(MethodInfo a,Type[]b){
if(b==null)return true;var c=a.GetParameters();if(c.Length!=b.Length)return
false;for(var d=0;d<b.Length;d++)if(!c[d].ParameterType.IsAssignableFrom(b[d]))
return false;return true;}}public static partial class Runtime{public static
readonly BindableProperty RegisterProperty=BindableProperty.CreateAttached(
"Register",typeof(string),typeof(Runtime),"",BindingMode.OneWay,null,
RegisterPropertyChanged);private static E _listenerInstance;private static void
RegisterPropertyChanged(BindableObject a,object b,object c){try{var d=Device.OS
==TargetPlatform.Android||Device.OS==TargetPlatform.iOS||Device.OS==
TargetPlatform.Windows||Device.OS==TargetPlatform.WinPhone;if(d&&
_listenerInstance==null)_listenerInstance=E.Instance;}catch(Exception e){D.
WriteLine(e.ToString());throw;}var f=(string)c;if(!f.Equals(RuntimeUpdateHandler
.CurrentlyUpdatedTargetId,StringComparison.OrdinalIgnoreCase)){Device.
BeginInvokeOnMainThread(()=>{LoadComponent(a,f);});}Device.
BeginInvokeOnMainThread(()=>{RuntimeUpdateHandler.Register(a,f);});}public
static void SetRegister(BindableObject a,string b){a.SetValue(RegisterProperty,b
);}public static string GetRegister(BindableObject a){return(string)a.GetValue(
RegisterProperty);}private static readonly Queue<Tuple<Element,string>>n=new
Queue<Tuple<Element,string>>();private static void o(object a,string b){foreach(
var value in b.Split(','))LoadComponent(a,value);}public static bool
LoadComponent(object a,string b){try{var c=RuntimeUpdateHandler.
GetInitialPropertyList(b)??"";var d=RuntimeUpdateHandler.FindBuffer(b);if(d!=
null){RuntimeUpdateHandler.ClearElement(a,b,c);RuntimeUpdateHandler.
InitializeComponent(a,d);return true;}else if(XamlLoader.XamlFileProvider!=null)
{var f=XamlLoader.XamlFileProvider(a.GetType())!=null;D.WriteLine(b+
" has xaml resource: "+f);if(f){RuntimeUpdateHandler.ClearElement(a,b,c);a.
LoadFromXaml(a.GetType());return true;}}return false;}catch(
NullReferenceException){}catch(Exception e){D.WriteLine(
"Failed to initialize with: "+b);D.WriteLine(e.Message);}return false;}}public
class RuntimeUpdateHandler{public static string CurrentlyUpdatedTargetId{get;
private set;}static readonly HashSet<object>n=new HashSet<object>();static
readonly Dictionary<object,object>o=new Dictionary<object,object>();static
readonly Dictionary<object,string>p=new Dictionary<object,string>();static
readonly Dictionary<string,HashSet<object>>q=new Dictionary<string,HashSet<
object>>();static readonly Dictionary<string,byte[]>r=new Dictionary<string,byte
[]>();static readonly Dictionary<string,string>s=new Dictionary<string,string>()
;public static void Register(object a,string b){b=b.ToLower();HashSet<object>c;
if(!q.TryGetValue(b,out c))q[b]=c=new HashSet<object>();c.Add(a);p[a]=b;n.Add(a)
;t(a);D.WriteLine("Registered '"+b+"' as "+a);}private static void t(object a){
var b=a as Element;if(b==null)return;var c=b;var d=b.Parent;while(d!=null){if(o.
ContainsKey(c))break;o[c]=d;c=d;d=c.Parent;}}public static byte[]FindBuffer(
string a){a=a.ToLower();byte[]b;if(r.TryGetValue(a,out b))return b;return null;}
public static void ReceiveMessages(List<Message>a){D.WriteLine(
"ReceiveMessages count "+a.Count.ToString());foreach(var message in a){message.
TargetId=message.TargetId.ToLower();r[message.TargetId]=message.Buffer;}var b=
new List<HashSet<object>>();foreach(var pageMessage in a){HashSet<object>c;if(q.
TryGetValue(pageMessage.TargetId,out c)){b.Add(c);}}var d=z(b.SelectMany(f=>f).
ToList());foreach(var root in d){var g=root;string h;if(!p.TryGetValue(g,out h))
{D.WriteLine("ReceiveMessages couldn't find in ObjectToTarget");continue;}var i=
a.FirstOrDefault(j=>j.TargetId==h);if(i==null){D.WriteLine(
"ReceiveMessages page message for "+h+" not found");continue;}D.WriteLine(
"Updating '"+i.TargetId+"' as "+g);if(g!=Application.Current)w(g);
CurrentlyUpdatedTargetId=i.TargetId;ClearElement(g,i.TargetId,i.PropertyList);
InitializeComponent(g,i.Buffer);}}public static void InitializeComponent(object
a,byte[]b){try{D.WriteLine("InitializeComponent "+a);var c=typeof(Xamarin.Forms.
Xaml.Extensions).GetTypeInfo();var d=c.DeclaredMethods.FirstOrDefault(f=>{if(f.
Name!="LoadFromXaml")return false;var g=f.GetParameters();return g.Length==2&&g[
1].ParameterType==typeof(string);});var h=d.MakeGenericMethod(typeof(object));
var i=Encoding.Unicode.GetString(b,0,b.Length);h.Invoke(null,new[]{a,i});if(a is
Application)u((Application)a);}catch(TargetInvocationException e){v(a,e.
InnerException);}catch(Exception e){v(a,e);}}private static void u(Application a
){string b;if(p.TryGetValue(a.MainPage,out b)){CurrentlyUpdatedTargetId=b;if(!
Runtime.LoadComponent(a.MainPage,b)){try{a.MainPage=(Page)Activator.
CreateInstance(a.MainPage.GetType());}catch(Exception e){Debug.WriteLine(
"Failed to create instance of MainPage");Debug.WriteLine(e);}}}}private static
void v(object a,Exception b){var c=b.Message;var d=b.InnerException;while(d!=
null){c+=Environment.NewLine+d.Message;d=d.InnerException;}var f=new Label{Text=
c,TextColor=Color.Red};if(a is ContentPage){((ContentPage)a).Content=f;}else if(
a is ContentView){((ContentView)a).Content=f;}Debug.WriteLine(c);}private static
void w(object a){var b=a as Element;if(b!=null){foreach(var child in B(b)){if(n.
Contains(child)){string c;if(p.TryGetValue(child,out c)){HashSet<object>d;if(q.
TryGetValue(c,out d))d.Remove(child);p.Remove(child);o.Remove(child);}n.Remove(
child);}}}}public static void ClearElement(object a,string b,string c){
ClearChildren(a);var d=a as Element;if(d!=null){var f=NameScope.GetNameScope(d)
as NameScope;if(f!=null){}}if(c!=null)x(a,b,c);}public static void ClearChildren
(object a){try{if(a is ContentPage){((ContentPage)a).Content=null;}else if(a is
ContentView){((ContentView)a).Content=null;}else if(a is ScrollView){((
ScrollView)a).Content=null;}else if(a is ContentPresenter){((ContentPresenter)a)
.Content=null;}else if(a is Frame){((Frame)a).Content=null;}else if(a is
StackLayout){((StackLayout)a).Children.Clear();}else if(a is AbsoluteLayout){((
AbsoluteLayout)a).Children.Clear();}else if(a is RelativeLayout){((
RelativeLayout)a).Children.Clear();}if(a is Page){((Page)a).ToolbarItems.Clear()
;}if(a is Application){var b=(Application)a;b.Resources.Clear();}}catch(
Exception e){D.WriteLine("Unable to ClearChildren: "+e);}}public static string
GetInitialPropertyList(string a){string b;if(s.TryGetValue(a,out b))return b;
return null;}private static void x(object a,string b,string c){var d=a as
Element;if(d==null)return;s[b]=c;foreach(var property in c.Split(',')){if(string
.IsNullOrWhiteSpace(property))continue;D.WriteLine("ResetProperty "+property);
var f=property;var g=f.LastIndexOf('.');if(g!=-1){var h=f.Substring(0,g);var i=f
.Substring(g+1);var j=KnownTypes.FindShortTypeWithProperty(h,i);if(j==null)
continue;var k=j.Item2;var l=(BindableProperty)k.GetValue(null);d.ClearValue(l);
}else{var m=a.GetType();y(d,m,property);}}}private static void y(Element a,Type
b,string c){var d=KnownTypes.FindBindablePropertyField(b,c);if(d==null){D.
WriteLine("Dependency property "+c+" not found on type "+b.FullName);return;}var
f=(BindableProperty)d.GetValue(null);a.ClearValue(f);}private static HashSet<
object>z(IList<object>a){var b=new HashSet<object>();foreach(var element in a){
var c=element as Element;if(c!=null){var d=A(c);var f=d.LastOrDefault(g=>a.Any(h
=>h!=element&&h==g));b.Add(f??element);}else{b.Add(element);}}return b;}private
static IList<Element>A(Element a){var b=new List<Element>();var c=a.Parent;while
(c!=null){b.Add(c);var d=c;c=d.Parent;}return b;}private static IEnumerable<
Element>B(Element a){var b=(IElementController)a;foreach(var child in b.
LogicalChildren){yield return child;foreach(var grandChild in B(child))yield
return grandChild;}}}class G{private const int n=53031;private readonly string[]
o;private readonly Action p;private readonly Action<string>q;private readonly
byte[]r=new byte[1];private int s=-1;private string t;private AutoResetEvent u=
new AutoResetEvent(false);public G(string[]a,Action<string>b,Action c){o=a;q=b;p
=c;v().ContinueWith(d=>{if(d.Exception!=null){D.n("ServerLocator error");D.n(d.
Exception.ToString());}});}private async Task v(){s++;if(s>o.Length-1){p();
return;}var a=o[s];try{var b=new I();D.n("Connecting to handshake server "+a);b.
r(a,n).Wait(50);var c=b.Client;c.BeginReceive(r,0,r.Length,0,d=>x(d,c),a);await
Task.Delay(500).ContinueWith(f=>u.Set());await w();if(string.IsNullOrWhiteSpace(
t)){D.WriteLine("Handshake server unreachable "+a);c.Close();await v();}else{q(t
);}}catch(Exception e){D.n("Handshake failed for "+a);D.Exception(e);await v();}
}private Task w(){return Task.Run(()=>u.WaitOne());}private void x(IAsyncResult
a,SocketProxy b){try{var c=(string)a.AsyncState;var d=b.EndReceive(a);if(d==1&&r
[0]==0xAA){t=c;u.Set();}}catch(Exception e){D.WriteLine(
"Handshake EndReceive failed");D.Exception(e);}}}public class IPAddressProxy{
private static bool n;private static ConstructorInfo o;public static object Any{
get{if(!n)p();return o.Invoke(new object[]{0});}}private static void p(){var a=
KnownTypes.FindType("System.Net.IPAddress");o=a.FindConstructor(typeof(long));if
(o==null)throw new Exception("IPAddress constructor not found");n=true;}}class H
{public object Object{get;}public H(object a,int b){var c=KnownTypes.FindType(
"System.Net.IPEndPoint");var d=KnownTypes.FindType("System.Net.IPAddress");var f
=c.FindConstructor(d,typeof(int));Object=f.Invoke(new[]{a,b});}}public class
SocketProxy{public object Object{get;}private readonly MethodInfo n;private
readonly MethodInfo o;private readonly MethodInfo p;private readonly MethodInfo
q;private readonly PropertyInfo r;private readonly PropertyInfo s;public int
ReceiveTimeout{get{return(int)r.GetValue(Object);}set{r.SetValue(Object,value);}
}public bool Blocking{get{return(bool)s.GetValue(Object);}set{s.SetValue(Object,
value);}}private SocketProxy(object a){Object=a;var b=KnownTypes.FindType(
"System.Net.Sockets.Socket");var c=KnownTypes.FindType(
"System.Net.Sockets.SocketFlags");q=b.GetMethod("Close",true);p=b.GetMethod(
"Receive",true,new Type[]{typeof(byte[])});n=b.GetMethod("BeginReceive",true,new
Type[]{typeof(byte[]),typeof(int),typeof(int),c,typeof(AsyncCallback),typeof(
object)});o=b.GetMethod("EndReceive",true,new Type[]{typeof(IAsyncResult)});r=b.
GetRuntimeProperty("ReceiveTimeout");s=b.GetRuntimeProperty("Blocking");}public
static SocketProxy FromObject(object a){return new SocketProxy(a);}public void
Close(){q.Invoke(Object,new object[0]);}public int Receive(byte[]a){return(int)p
.Invoke(Object,new[]{a});}public IAsyncResult BeginReceive(byte[]a,int b,int c,
int d,AsyncCallback f,object g){return(IAsyncResult)n.Invoke(Object,new[]{a,b,c,
(int)d,f,g});}public int EndReceive(IAsyncResult a){return(int)o.Invoke(Object,
new object[]{a});}}class I{private MethodInfo n;private PropertyInfo o;private
SocketProxy p;private object q{get;}public SocketProxy Client{get{if(q==null)
throw new InvalidOperationException("Object is not initialized yet");return p??(
p=SocketProxy.FromObject(o.GetValue(q)));}}public I(){var a=KnownTypes.FindType(
"System.Net.Sockets.TcpClient");var b=KnownTypes.GetConstructor(a);n=a.GetMethod
("ConnectAsync",true,new Type[]{typeof(string),typeof(int)});o=a.
GetRuntimeProperty("Client");q=b.Invoke(new object[0]);}internal Task r(string a
,int b){return(Task)n.Invoke(q,new object[]{a,b});}}class J{private MethodInfo n
;private MethodInfo o;public object Object{get;private set;}public J(int a){var
b=KnownTypes.FindType("System.Net.Sockets.UdpClient");var c=KnownTypes.
GetConstructor(b,typeof(int));var d=KnownTypes.FindType("System.Net.IPEndPoint")
;n=b.GetMethod("BeginReceive",true,new Type[]{typeof(AsyncCallback),typeof(
object)});o=b.GetMethod("EndReceive",true,new Type[]{typeof(IAsyncResult),d.
MakeByRefType()});Object=c.Invoke(new object[]{a});}public void BeginReceive(
AsyncCallback a,object b){n.Invoke(Object,new object[]{a,b});}public byte[]
EndReceive(IAsyncResult a,ref object b){return(byte[])o.Invoke(Object,new object
[]{a,b});}}
internal class __internal { public static readonly BindableProperty RegisterProperty = Runtime.RegisterProperty; } } 