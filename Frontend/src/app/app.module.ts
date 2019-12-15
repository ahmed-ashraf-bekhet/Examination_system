import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router'

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { GuestHeaderComponent } from './components/guest-header/guest-header.component';
import { SliderComponent } from './components/slider/slider.component';
import { BannerFeatureComponent } from './components/banner-feature/banner-feature.component';
import { HomeComponent } from './components/home/home.component';
import { CoursesComponent } from './components/courses/courses.component';
import { SeeAllHeaderComponent } from './components/see-all-header/see-all-header.component';
import { ErrorComponent } from './components/error/error.component';
import { CourseSingleComponent } from './components/course-single/course-single.component';
import { CoursesListComponent } from './components/courses-list/courses-list.component';
import { SecondrayHeaderComponent } from './components/secondray-header/secondray-header.component';
import { DepartmentsComponent } from './components/departments/departments.component';
import { DepartmentSingleComponent } from './components/department-single/department-single.component';
import { TeachersComponent } from './components/teachers/teachers.component';
import { TeacherSingleComponent } from './components/teacher-single/teacher-single.component';

import { CourseService } from './services/course.service';
import { UserService } from './services/user.service';
import { TestComponent } from './components/test/test.component';
import { CookieService } from 'ngx-cookie-service';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatDialogModule} from '@angular/material/dialog';

import { StudentSingleComponent } from './components/student-single/student-single.component';
import { UpdateUserModalComponent } from './components/popups/UpdateUserModal/UpdateUserModal.component';
import { AboutComponent } from './components/about/about.component';
import { TeachersListComponent } from './components/teachers-list/teachers-list.component';
import { ActiveLinkDirective } from './directives/active-link.directive';
import { CreateQuestionsComponent } from './components/popups/create-questions/create-questions.component';

import { LoginModalComponent } from './components/popups/login-modal/login-modal.component';
import { TopicsComponent } from './components/topics/topics.component';
import { AuthService } from './services/auth.service';
import { TopicService } from './services/topic.service';
import { DepartmentService } from './services/department.service';
import { AddDepartmentModalComponent } from './components/popups/add-department-modal/add-department-modal.component';
import { AddCourseModalComponent } from './components/popups/add-course-modal/add-course-modal.component';
import { ExamsModalComponent } from './components/popups/exams-modal/exams-modal.component';
import { QuestionsComponent } from './components/questions/questions.component';
import { GenerateExamModalComponent } from './components/popups/generate-exam-modal/generate-exam-modal.component';
import { UpdateTopicModalComponent } from './components/popups/update-topic-modal/update-topic-modal.component';
import { UpdateDepartmentModalComponent } from './components/popups/update-department-modal/update-department-modal.component';
import { UpdateCourseModalComponent } from './components/popups/update-course-modal/update-course-modal.component';
import { AddStudentModalComponent } from './components/popups/add-student-modal/add-student-modal.component';
import { AddTeacherModalComponent } from './components/popups/add-teacher-modal/add-teacher-modal.component';
import { AssignStudentModalComponent } from './components/popups/assign-student-modal/assign-student-modal.component';
import { AddTopicModalComponent } from './components/popups/add-topic-modal/add-topic-modal.component';
import { HomeAboutComponent } from './components/home-about/home-about.component';
import { ContactComponent } from './components/contact/contact.component';
import { StudentAnswersModalComponent } from './components/popups/student-answers-modal/student-answers-modal.component';

const AppRoutes = [
  { path: '', component: HomeComponent },
  { path: 'test', component: TestComponent },
  { path: 'courses', component: CoursesComponent },
  { path: 'courses/:id', component: CourseSingleComponent },
  { path: 'departments', component: DepartmentsComponent },
  { path: 'departments/:id', component: DepartmentSingleComponent },
  { path: 'teachers', component: TeachersComponent },
  { path: 'students/:id', component: StudentSingleComponent },
  { path: 'teachers/:id', component: TeacherSingleComponent },
  { path: 'about', component: AboutComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'questions/:id', component: QuestionsComponent },
  { path: '**', component: ErrorComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    GuestHeaderComponent,
    SliderComponent,
    BannerFeatureComponent,
    HomeComponent,
    CreateQuestionsComponent,
    CoursesComponent,
    SeeAllHeaderComponent,
    ErrorComponent,
    CourseSingleComponent,
    CoursesListComponent,
    SecondrayHeaderComponent,
    DepartmentsComponent,
    DepartmentSingleComponent,
    TeachersComponent,
    TeacherSingleComponent,
    TestComponent,
    StudentSingleComponent,
    UpdateUserModalComponent,
    AboutComponent,
    TeachersListComponent,
    ActiveLinkDirective,
    LoginModalComponent,
    TopicsComponent,
    AddDepartmentModalComponent,
    AddCourseModalComponent,
    ExamsModalComponent,
    QuestionsComponent,
    GenerateExamModalComponent,
    UpdateTopicModalComponent,
    UpdateDepartmentModalComponent,
    UpdateCourseModalComponent,
    AddStudentModalComponent,
    AddTeacherModalComponent,
    AssignStudentModalComponent,
    AddTopicModalComponent,
    HomeAboutComponent,
    ContactComponent,
    StudentAnswersModalComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule,
    RouterModule.forRoot(AppRoutes)

  ],
  entryComponents:[CreateQuestionsComponent],
  providers: [CourseService,UserService,CookieService,AuthService,TopicService
              ,DepartmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
