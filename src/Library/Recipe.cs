//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    /// <summary>
    /// Agregé el metodo getproductioncost junto con dos metodos que calculan cada uno subtotales en esta clase
    /// ya que utilizando el patron Expert la clase que contiene toda la informacion necesaria para ejecutar
    /// una tarea debe ejecutarla.
    /// Como justificacion de los metodos, quise dividir la tarea de calcular el total para que en caso de que se quiera
    /// obtener el costo total de el uso de el equipamiento o el costo de todos los productos utilizados no se tenga
    /// que crear nuevos metodos, ademas de que dejo a la clase total encargada solamente de sumar dichos resultados.
    /// </summary>
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }


        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"El costo total de realizar la receta fue: {GetProductionCost()}");
        }
        public double GetEquipmentCost()
        {
            double subtotal = 0;
            foreach (Step step in this.steps)
            {
                subtotal += step.Time * step.Equipment.HourlyCost;
            }
            return subtotal;
        }

        public double GetInputCost()
        {
            double subtotal = 0;
            foreach (Step step in this.steps)
            {
                subtotal += step.Input.UnitCost * step.Quantity;
            }
            return subtotal;
        }
        public double GetProductionCost()
        {
            double ProductionCost = GetEquipmentCost() + GetInputCost();
            return ProductionCost;
        }
    }
}