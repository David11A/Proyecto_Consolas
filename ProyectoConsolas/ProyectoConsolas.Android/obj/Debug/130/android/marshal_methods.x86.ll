; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [180 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 47
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 76
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 6
	i32 57263871, ; 3: Xamarin.Forms.Core.dll => 0x369c6ff => 71
	i32 101534019, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 61
	i32 117431740, ; 5: System.Runtime.InteropServices => 0x6ffddbc => 88
	i32 120558881, ; 6: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 61
	i32 165246403, ; 7: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 28
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 62
	i32 185010651, ; 9: System.Net.Http.Primitives => 0xb0709db => 12
	i32 209399409, ; 10: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 26
	i32 225384260, ; 11: ProyectoConsolas.dll => 0xd6f1744 => 7
	i32 230216969, ; 12: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 42
	i32 232815796, ; 13: System.Web.Services => 0xde07cb4 => 86
	i32 261689757, ; 14: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 31
	i32 278686392, ; 15: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 46
	i32 280482487, ; 16: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 40
	i32 318968648, ; 17: Xamarin.AndroidX.Activity.dll => 0x13031348 => 18
	i32 321597661, ; 18: System.Numerics => 0x132b30dd => 13
	i32 342366114, ; 19: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 44
	i32 426391589, ; 20: ProyectoConsolas.Android => 0x196a3825 => 0
	i32 441335492, ; 21: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 30
	i32 442521989, ; 22: Xamarin.Essentials => 0x1a605985 => 70
	i32 450948140, ; 23: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 39
	i32 465846621, ; 24: mscorlib => 0x1bc4415d => 5
	i32 469710990, ; 25: System.dll => 0x1bff388e => 9
	i32 476646585, ; 26: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 40
	i32 486930444, ; 27: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 51
	i32 526420162, ; 28: System.Transactions.dll => 0x1f6088c2 => 81
	i32 605376203, ; 29: System.IO.Compression.FileSystem => 0x24154ecb => 84
	i32 627609679, ; 30: Xamarin.AndroidX.CustomView => 0x2568904f => 35
	i32 663517072, ; 31: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 67
	i32 666292255, ; 32: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 23
	i32 690569205, ; 33: System.Xml.Linq.dll => 0x29293ff5 => 17
	i32 775507847, ; 34: System.IO.Compression => 0x2e394f87 => 83
	i32 809851609, ; 35: System.Drawing.Common.dll => 0x30455ad9 => 78
	i32 843511501, ; 36: Xamarin.AndroidX.Print => 0x3246f6cd => 58
	i32 928116545, ; 37: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 76
	i32 955402788, ; 38: Newtonsoft.Json => 0x38f24a24 => 6
	i32 967690846, ; 39: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 44
	i32 974778368, ; 40: FormsViewGroup.dll => 0x3a19f000 => 2
	i32 1012816738, ; 41: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 60
	i32 1035644815, ; 42: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 22
	i32 1042160112, ; 43: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 73
	i32 1052210849, ; 44: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 48
	i32 1098259244, ; 45: System => 0x41761b2c => 9
	i32 1175144683, ; 46: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 65
	i32 1178241025, ; 47: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 55
	i32 1204270330, ; 48: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 23
	i32 1267360935, ; 49: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 66
	i32 1293217323, ; 50: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 37
	i32 1365406463, ; 51: System.ServiceModel.Internals.dll => 0x516272ff => 77
	i32 1376866003, ; 52: Xamarin.AndroidX.SavedState => 0x52114ed3 => 60
	i32 1395857551, ; 53: Xamarin.AndroidX.Media.dll => 0x5333188f => 52
	i32 1406073936, ; 54: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 32
	i32 1460219004, ; 55: Xamarin.Forms.Xaml => 0x57092c7c => 74
	i32 1462112819, ; 56: System.IO.Compression.dll => 0x57261233 => 83
	i32 1469204771, ; 57: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 21
	i32 1582372066, ; 58: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 36
	i32 1592978981, ; 59: System.Runtime.Serialization.dll => 0x5ef2ee25 => 1
	i32 1622152042, ; 60: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 50
	i32 1624863272, ; 61: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 69
	i32 1636350590, ; 62: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 34
	i32 1639515021, ; 63: System.Net.Http.dll => 0x61b9038d => 10
	i32 1657153582, ; 64: System.Runtime => 0x62c6282e => 15
	i32 1658241508, ; 65: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 63
	i32 1658251792, ; 66: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 75
	i32 1670060433, ; 67: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 31
	i32 1677501392, ; 68: System.Net.Primitives.dll => 0x63fca3d0 => 89
	i32 1729485958, ; 69: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 27
	i32 1766324549, ; 70: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 62
	i32 1776026572, ; 71: System.Core.dll => 0x69dc03cc => 8
	i32 1788241197, ; 72: Xamarin.AndroidX.Fragment => 0x6a96652d => 39
	i32 1808609942, ; 73: Xamarin.AndroidX.Loader => 0x6bcd3296 => 50
	i32 1813201214, ; 74: Xamarin.Google.Android.Material => 0x6c13413e => 75
	i32 1818569960, ; 75: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 56
	i32 1867746548, ; 76: Xamarin.Essentials.dll => 0x6f538cf4 => 70
	i32 1878053835, ; 77: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 74
	i32 1885316902, ; 78: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 24
	i32 1919157823, ; 79: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 53
	i32 2019465201, ; 80: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 48
	i32 2055257422, ; 81: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 45
	i32 2079903147, ; 82: System.Runtime.dll => 0x7bf8cdab => 15
	i32 2090596640, ; 83: System.Numerics.Vectors => 0x7c9bf920 => 14
	i32 2097448633, ; 84: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 41
	i32 2126786730, ; 85: Xamarin.Forms.Platform.Android => 0x7ec430aa => 72
	i32 2201231467, ; 86: System.Net.Http => 0x8334206b => 10
	i32 2217644978, ; 87: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 65
	i32 2244775296, ; 88: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 51
	i32 2256548716, ; 89: Xamarin.AndroidX.MultiDex => 0x8680336c => 53
	i32 2261435625, ; 90: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 43
	i32 2279755925, ; 91: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 59
	i32 2315684594, ; 92: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 19
	i32 2353062107, ; 93: System.Net.Primitives => 0x8c40e0db => 89
	i32 2409053734, ; 94: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 57
	i32 2465532216, ; 95: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 30
	i32 2471841756, ; 96: netstandard.dll => 0x93554fdc => 79
	i32 2475788418, ; 97: Java.Interop.dll => 0x93918882 => 3
	i32 2501346920, ; 98: System.Data.DataSetExtensions => 0x95178668 => 82
	i32 2505896520, ; 99: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 47
	i32 2581819634, ; 100: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 66
	i32 2620871830, ; 101: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 34
	i32 2624644809, ; 102: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 38
	i32 2629600743, ; 103: System.Net.Http.Extensions.dll => 0x9cbc85e7 => 11
	i32 2633051222, ; 104: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 46
	i32 2701096212, ; 105: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 63
	i32 2702597487, ; 106: ProyectoConsolas.Android.dll => 0xa1165d6f => 0
	i32 2732626843, ; 107: Xamarin.AndroidX.Activity => 0xa2e0939b => 18
	i32 2737747696, ; 108: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 21
	i32 2766581644, ; 109: Xamarin.Forms.Core => 0xa4e6af8c => 71
	i32 2778768386, ; 110: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 68
	i32 2810250172, ; 111: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 32
	i32 2819470561, ; 112: System.Xml.dll => 0xa80db4e1 => 16
	i32 2853208004, ; 113: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 68
	i32 2855708567, ; 114: Xamarin.AndroidX.Transition => 0xaa36a797 => 64
	i32 2903344695, ; 115: System.ComponentModel.Composition => 0xad0d8637 => 85
	i32 2905242038, ; 116: mscorlib.dll => 0xad2a79b6 => 5
	i32 2916838712, ; 117: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 69
	i32 2919462931, ; 118: System.Numerics.Vectors.dll => 0xae037813 => 14
	i32 2921128767, ; 119: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 20
	i32 2978675010, ; 120: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 37
	i32 3024354802, ; 121: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 42
	i32 3044182254, ; 122: FormsViewGroup => 0xb57288ee => 2
	i32 3057625584, ; 123: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 54
	i32 3111772706, ; 124: System.Runtime.Serialization => 0xb979e222 => 1
	i32 3204380047, ; 125: System.Data.dll => 0xbefef58f => 80
	i32 3211777861, ; 126: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 36
	i32 3247949154, ; 127: Mono.Security => 0xc197c562 => 87
	i32 3258312781, ; 128: Xamarin.AndroidX.CardView => 0xc235e84d => 27
	i32 3267021929, ; 129: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 25
	i32 3317135071, ; 130: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 35
	i32 3317144872, ; 131: System.Data => 0xc5b79d28 => 80
	i32 3340431453, ; 132: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 24
	i32 3346324047, ; 133: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 55
	i32 3353484488, ; 134: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 41
	i32 3362522851, ; 135: Xamarin.AndroidX.Core => 0xc86c06e3 => 33
	i32 3366347497, ; 136: Java.Interop => 0xc8a662e9 => 3
	i32 3374999561, ; 137: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 59
	i32 3404865022, ; 138: System.ServiceModel.Internals => 0xcaf21dfe => 77
	i32 3429136800, ; 139: System.Xml => 0xcc6479a0 => 16
	i32 3430777524, ; 140: netstandard => 0xcc7d82b4 => 79
	i32 3441283291, ; 141: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 38
	i32 3476120550, ; 142: Mono.Android => 0xcf3163e6 => 4
	i32 3486566296, ; 143: System.Transactions => 0xcfd0c798 => 81
	i32 3493954962, ; 144: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 29
	i32 3501239056, ; 145: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 25
	i32 3509114376, ; 146: System.Xml.Linq => 0xd128d608 => 17
	i32 3522916314, ; 147: System.Net.Http.Extensions => 0xd1fb6fda => 11
	i32 3536029504, ; 148: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 72
	i32 3567349600, ; 149: System.ComponentModel.Composition.dll => 0xd4a16f60 => 85
	i32 3618140916, ; 150: Xamarin.AndroidX.Preference => 0xd7a872f4 => 57
	i32 3627220390, ; 151: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 58
	i32 3632359727, ; 152: Xamarin.Forms.Platform => 0xd881692f => 73
	i32 3633644679, ; 153: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 20
	i32 3641597786, ; 154: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 45
	i32 3672681054, ; 155: Mono.Android.dll => 0xdae8aa5e => 4
	i32 3676310014, ; 156: System.Web.Services.dll => 0xdb2009fe => 86
	i32 3682565725, ; 157: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 26
	i32 3684561358, ; 158: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 29
	i32 3689375977, ; 159: System.Drawing.Common => 0xdbe768e9 => 78
	i32 3718780102, ; 160: Xamarin.AndroidX.Annotation => 0xdda814c6 => 19
	i32 3724971120, ; 161: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 54
	i32 3758932259, ; 162: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 43
	i32 3786282454, ; 163: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 28
	i32 3798658073, ; 164: System.Net.Http.Primitives.dll => 0xe26aec19 => 12
	i32 3822602673, ; 165: Xamarin.AndroidX.Media => 0xe3d849b1 => 52
	i32 3829621856, ; 166: System.Numerics.dll => 0xe4436460 => 13
	i32 3849253459, ; 167: System.Runtime.InteropServices.dll => 0xe56ef253 => 88
	i32 3885922214, ; 168: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 64
	i32 3896760992, ; 169: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 33
	i32 3920810846, ; 170: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 84
	i32 3921031405, ; 171: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 67
	i32 3931092270, ; 172: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 56
	i32 3945713374, ; 173: System.Data.DataSetExtensions.dll => 0xeb2ecede => 82
	i32 3955647286, ; 174: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 22
	i32 4105002889, ; 175: Mono.Security.dll => 0xf4ad5f89 => 87
	i32 4151237749, ; 176: System.Core => 0xf76edc75 => 8
	i32 4182413190, ; 177: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 49
	i32 4222480024, ; 178: ProyectoConsolas => 0xfbadee98 => 7
	i32 4292120959 ; 179: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 49
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [180 x i32] [
	i32 47, i32 76, i32 6, i32 71, i32 61, i32 88, i32 61, i32 28, ; 0..7
	i32 62, i32 12, i32 26, i32 7, i32 42, i32 86, i32 31, i32 46, ; 8..15
	i32 40, i32 18, i32 13, i32 44, i32 0, i32 30, i32 70, i32 39, ; 16..23
	i32 5, i32 9, i32 40, i32 51, i32 81, i32 84, i32 35, i32 67, ; 24..31
	i32 23, i32 17, i32 83, i32 78, i32 58, i32 76, i32 6, i32 44, ; 32..39
	i32 2, i32 60, i32 22, i32 73, i32 48, i32 9, i32 65, i32 55, ; 40..47
	i32 23, i32 66, i32 37, i32 77, i32 60, i32 52, i32 32, i32 74, ; 48..55
	i32 83, i32 21, i32 36, i32 1, i32 50, i32 69, i32 34, i32 10, ; 56..63
	i32 15, i32 63, i32 75, i32 31, i32 89, i32 27, i32 62, i32 8, ; 64..71
	i32 39, i32 50, i32 75, i32 56, i32 70, i32 74, i32 24, i32 53, ; 72..79
	i32 48, i32 45, i32 15, i32 14, i32 41, i32 72, i32 10, i32 65, ; 80..87
	i32 51, i32 53, i32 43, i32 59, i32 19, i32 89, i32 57, i32 30, ; 88..95
	i32 79, i32 3, i32 82, i32 47, i32 66, i32 34, i32 38, i32 11, ; 96..103
	i32 46, i32 63, i32 0, i32 18, i32 21, i32 71, i32 68, i32 32, ; 104..111
	i32 16, i32 68, i32 64, i32 85, i32 5, i32 69, i32 14, i32 20, ; 112..119
	i32 37, i32 42, i32 2, i32 54, i32 1, i32 80, i32 36, i32 87, ; 120..127
	i32 27, i32 25, i32 35, i32 80, i32 24, i32 55, i32 41, i32 33, ; 128..135
	i32 3, i32 59, i32 77, i32 16, i32 79, i32 38, i32 4, i32 81, ; 136..143
	i32 29, i32 25, i32 17, i32 11, i32 72, i32 85, i32 57, i32 58, ; 144..151
	i32 73, i32 20, i32 45, i32 4, i32 86, i32 26, i32 29, i32 78, ; 152..159
	i32 19, i32 54, i32 43, i32 28, i32 12, i32 52, i32 13, i32 88, ; 160..167
	i32 64, i32 33, i32 84, i32 67, i32 56, i32 82, i32 22, i32 87, ; 168..175
	i32 8, i32 49, i32 7, i32 49 ; 176..179
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ a8a26c7b003e2524cc98acb2c2ffc2ddea0f6692"}
!llvm.linker.options = !{}
