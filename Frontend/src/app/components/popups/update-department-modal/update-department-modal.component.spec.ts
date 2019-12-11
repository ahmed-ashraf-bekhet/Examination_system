import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateDepartmentModalComponent } from './update-department-modal.component';

describe('UpdateDepartmentModalComponent', () => {
  let component: UpdateDepartmentModalComponent;
  let fixture: ComponentFixture<UpdateDepartmentModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateDepartmentModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateDepartmentModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
