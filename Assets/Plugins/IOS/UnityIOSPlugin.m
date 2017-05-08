//
//  UnityIOSPlugin.m
//
//

#import "UnityIOSPlugin.h"

#if defined(__cpluscplus)
extern "C"{
#endif
    //unity 回调声明
    extern void UnitySendMessage(const char *, const char *, const char *);
    extern NSString *CreateNSString(const char *string);
    
    //字符串转化的工具函数
    NSString* _CreateNSString (const char* string)
    {
        if (string)
            return [NSString stringWithUTF8String: string];
        else
            return [NSString stringWithUTF8String: ""];
    }
   
    void _HelloIOS(const char * string)
    {
		[[UnityIOSPlugin sharedManager] showAlertMessage:@"" message:_CreateNSString(shareMessage)];
		
		//回调unity函数
		UnitySendMessage([@"IOSPlugins" UTF8String],[@"HelloIOSCallBack" UTF8String], [@"Hello Unity" UTF8String]);    
    }
	
    
#if defined(__cplusplus)
}
#endif

@implementation UnityIOSPlugin

#pragma mark - LifeCycle
+(instancetype)sharedManager {
    static dispatch_once_t onceToken;
    static WXApiManager *instance;
    dispatch_once(&onceToken, ^{
        instance = [[WXApiManager alloc] init];
    });
    return instance;
}

- (void)dealloc {
    self.delegate = nil;
    [super dealloc];
}

- (void)showAlertMessage:(NSString *) strTitle message:(NSString *) strMsg {

    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:strTitle
                                                    message:strMsg
                                                   delegate:self
                                          cancelButtonTitle:@"OK"
                                          otherButtonTitles:nil, nil];
    [alert show];
    [alert release];
}
@end
