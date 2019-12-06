import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let CourseSingleComponent = class CourseSingleComponent {
    constructor(myService, myRouter) {
        this.myService = myService;
        this.myRouter = myRouter;
    }
    ngOnInit() {
        this.getCourse(this.myRouter.snapshot.params['id']);
    }
    getCourse(ID) {
        this.myService.getCourse(ID).subscribe((data) => {
            this.course = data[0];
        }, (error) => {
            console.log(error);
        });
    }
};
CourseSingleComponent = tslib_1.__decorate([
    Component({
        selector: 'app-course-single',
        templateUrl: './course-single.component.html',
        styleUrls: ['./course-single.component.css']
    })
], CourseSingleComponent);
export { CourseSingleComponent };
//# sourceMappingURL=course-single.component.js.map