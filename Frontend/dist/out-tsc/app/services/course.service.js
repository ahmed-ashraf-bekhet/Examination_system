import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
let CourseService = class CourseService {
    constructor(myHttp, authService) {
        this.myHttp = myHttp;
        this.authService = authService;
    }
    getAllCourses() {
        return this.myHttp.get("http://localhost:54345/api/Course");
    }
    getDepartmentCourses(ID) {
        return this.myHttp.get(`http://localhost:54345/api/GetDepartmentCourses/${ID}`);
    }
    getCourse(ID) {
        return this.myHttp.get(`http://localhost:54345/api/Course/${ID}`);
    }
    test(image) {
        const formData = new FormData();
        formData.append('image', image);
        const httpOptions = {
            headers: new HttpHeaders(this.authService.getCookie())
        };
        var course = {
            Name: "aa",
            Description: "55",
            image: image
        };
        return this.myHttp.post("http://localhost:54345/test/test", { course, image }, httpOptions);
    }
};
CourseService = tslib_1.__decorate([
    Injectable({
        providedIn: 'root'
    })
], CourseService);
export { CourseService };
//# sourceMappingURL=course.service.js.map