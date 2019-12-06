import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
let DepartmentService = class DepartmentService {
    constructor(myHttp) {
        this.myHttp = myHttp;
    }
    getAllDepartments() {
        return this.myHttp.get("http://localhost:1600/courses");
    }
    getDepartment(ID) {
        return this.myHttp.get(`http://localhost:1600/courses?ID=${ID}`);
    }
    getStudentsNumber(DepartmentID) {
        return 50;
    }
    getTeachersNumber(DepartmentID) {
        return 8;
    }
    getCoursesNumber(DepartmentID) {
        return 4;
    }
};
DepartmentService = tslib_1.__decorate([
    Injectable({
        providedIn: 'root'
    })
], DepartmentService);
export { DepartmentService };
//# sourceMappingURL=department.service.js.map