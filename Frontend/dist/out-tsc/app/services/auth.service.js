import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
let AuthService = class AuthService {
    constructor(cookie) {
        this.cookie = cookie;
    }
    getCookie() {
        // for testing
        this.setCookie(1, 2);
        return {
            'userID': this.cookie.get('userID'),
            'userTypeID': this.cookie.get('userTypeID')
        };
    }
    setCookie(userID, userTypeID) {
        this.cookie.set('userID', userID);
        this.cookie.set('userTypeID', userTypeID);
    }
};
AuthService = tslib_1.__decorate([
    Injectable({
        providedIn: 'root'
    })
], AuthService);
export { AuthService };
//# sourceMappingURL=auth.service.js.map