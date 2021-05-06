import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioNIComponent } from './formulario-ni.component';

describe('FormularioNIComponent', () => {
  let component: FormularioNIComponent;
  let fixture: ComponentFixture<FormularioNIComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormularioNIComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormularioNIComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
