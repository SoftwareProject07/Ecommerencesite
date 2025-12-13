import React from 'react';
import   "../component/styles/headers.css";
 

export default function Header() {
  return (
    <>
      {/* NAVBAR */}
      <nav className="navbar navbar-expand-lg navbar-light bg-light px-3">
        {/* <a className="navbar-brand" href="#">AKMedizostore</a> */}
<a className="navbar-brand d-flex align-items-center" href="#">
  <img 
    src="/AKMedizostore.png" 
    alt="AKMedizostore"
    style={{ width: "30px", height: "30px", marginRight: "8px" }}
  />
  AKMedizostore
</a>

        <button
          className="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarNav"
        >
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav me-auto">

            <li className="nav-item">
              <a className="nav-link" href="http://localhost:5173/header">Home</a>
            </li>

            <li className="nav-item">
              <a className="nav-link" href="#medicineOrder">Medicine Order</a>
            </li>

            <li className="nav-item">
              <a className="nav-link" href="#">About</a>
            </li>

          </ul>

          <form className="d-flex">
            <input
              className="form-control me-2"
              type="search"
              placeholder="Search Medicines"
            />
            <button className="btn btn-outline-success">Search</button>
          </form>
        </div>
      </nav>

      {/* FULL PAGE MEDICINE ORDER VIEW */}
      <div className="container-fluid mt-4" id="medicineOrder">
        <div className="row">

          {/* LEFT CATEGORIES */}
          <div className="col-md-3">
            <h4>Categories</h4>
            <ul className="list-group">
              <li className="list-group-item">Pain Relief</li>
              <li className="list-group-item">Antibiotics</li>
              <li className="list-group-item">Vitamins</li>
              <li className="list-group-item">Cough Syrup</li>
              <li className="list-group-item">Skin Care</li>
              <li className="list-group-item">Baby Care</li>
            </ul>
          </div>

          {/* RIGHT – MEDICINES */}
          <div className="col-md-9">
            <h3 className="mb-3">All Medicines</h3>

            <div className="row">

              {[
                { name: "Paracetamol", price: 25 },
                { name: "Amoxicillin", price: 60 },
                { name: "Vitamin C Tablets", price: 90 },
                { name: "Cough Syrup", price: 80 },
                { name: "Crocin", price: 35 },
                { name: "Skin Ointment", price: 50 }
              ].map((med, index) => (
                <div className="col-md-4 mb-4" key={index}>
                  <div className="card">
                    <img
                      src="https://via.placeholder.com/200"
                      className="card-img-top"
                      alt={med.name}
                    />
                    <div className="card-body">
                      <h5 className="card-title">{med.name}</h5>
                      <p>Price: ₹{med.price}</p>
                      <button className="btn btn-primary w-100">
                        Add to Cart
                      </button>
                    </div>
                  </div>
                </div>
              ))}

            </div>
          </div>

        </div>
      </div>
    </>
  );
}
