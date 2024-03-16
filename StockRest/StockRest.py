
from fastapi import FastAPI
import json

app = FastAPI()

productQty=[{"id":1,"qty":10},{"id":2,"qty":15}]

@app.get("/Products")
def get_product_quantity():
    return productQty   

@app.get("/Products/{id}")
def get_product_quantity_By_id(id:int):
    for i in productQty:
        if i["id"] == id:
            return i 
