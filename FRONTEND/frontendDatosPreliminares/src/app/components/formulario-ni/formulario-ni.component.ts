import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CarreraService } from 'src/app/services/carrera.service';
import { FormularioService } from 'src/app/services/formulario.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-formulario-ni',
  templateUrl: './formulario-ni.component.html',
  styleUrls: ['./formulario-ni.component.css']
})


export class FormularioNIComponent implements OnInit {

  carreras: any;
  valorCar ="0";
  valido : any;
  correo_valido: number = 0;
  // carreras: any[] = [
  //   {valor: "0", descripcion: "Selecciona una carrera", deshabilitada: true},
  //   {valor: "1", descripcion: "Doctorado en medicina", deshabilitada: false},
  //   {valor: "2", descripcion: "Doctorado en odontología", deshabilitada: false},
  //   {valor: "3", descripcion: "Ingeniería en sistemas informáticos", deshabilitada: false}
  // ];

form: FormGroup;

validadorEmail: any = /^(([^<>()\[\]\.,;:\s@\”]+(\.[^<>()\[\]\.,;:\s@\”]+)*)|(\”.+\”))@(([^<>()[\]\.,;:\s@\”]+\.)+[^<>()[\]\.,;:\s@\”]{2,})$/;
validadorTelefono: any = /^([0-9])*$/;

constructor(private fb: FormBuilder,
  private toastr: ToastrService, 
  private _niveles: CarreraService,
  private _formulario: FormularioService)
  { 
    this.form = this.fb.group
    ({
      correo: ['', [Validators.required, Validators.maxLength(300), Validators.pattern(this.validadorEmail) ]],
      telefono: ['',[Validators.required, Validators.minLength(8), Validators.pattern(this.validadorTelefono)]],
      nombre: ['',[Validators.required, Validators.maxLength(300)]],
      apellido: ['',[Validators.required, Validators.maxLength(300)]],
      fecha_nacimiento: ['',Validators.required],
      carrera_interes: ['0',Validators.required]
    })
  }

  
  ngOnInit(): void {
    this.obtenerNiveles();
  }

  obtenerNiveles()
  {
    this._niveles.getNiveles().subscribe(data => 
    {
      // console.log(data);
      this.carreras = data;
      // console.log(this.carreras);
      // console.log(this.carreras[2].nivdsc);
    }, error =>
    {
      console.log(error);
    })
  }

  solicitarFormulario()
  {
    const formulario: any =
    {
      correo: this.form.get('correo')?.value,
      telefono: this.form.get('telefono')?.value,
      nombre: this.form.get('nombre')?.value,
      apellido: this.form.get('apellido')?.value,
      fecha_nacimiento: this.form.get('fecha_nacimiento')?.value,
      carrera_interes: this.form.get('carrera_interes')?.value
    }
    //VERIFICAMOS EL CORREO INGRESADO SI YA EXISTE NO PUEDE SOLICITAR EL FORMULARIO
    this.correo_valido = this.verificarCorreo(this.correo?.value)

    if(this.correo_valido == 1)
    {
      Swal.fire('Información almacenada', '', 'success')
    }
    else
    {
      this.form.reset();
      this.carrera_interes?.setValue("0");
      Swal.fire('El correo que intentas ingresar ya fue utilizado', '', 'error')
    }
      // this.toastr.success('Guardado', 'La información fue guardada con éxito');
  }

  verificarCorreo(correo: string): number
  {
    this._formulario.getValidacionCorreoElectronico(correo).subscribe(data => 
      {
        this.valido = data;
        return parseInt(this.valido[0].resultado);
      }, error =>
      {
        console.log(error);
        return 0;
      }) 
    return 0;
  }

  get correo() { return this.form.get('correo'); }
  get telefono() { return this.form.get('telefono'); }
  get nombre() { return this.form.get('nombre'); }
  get apellido() { return this.form.get('apellido'); }
  get fecha_nacimiento() { return this.form.get('fecha_nacimiento'); }
  get carrera_interes() { return this.form.get('carrera_interes'); }

}
