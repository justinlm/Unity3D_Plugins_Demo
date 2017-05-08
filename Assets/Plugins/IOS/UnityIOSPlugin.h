//
//  UnityIOSPlugin.h
//  
//

#import <Foundation/Foundation.h>


@interface UnityIOSPlugin : NSObject

+ (instancetype)sharedManager;

- (void)showAlertMessage:(NSString *) strTitle message:(NSString *) strMsg;

@end
