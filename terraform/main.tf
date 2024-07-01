#################################################
#                    Databases                  #
#################################################
module "rds_instance" {
  database_name                         = "expense-control"
  source                                = "./modules/rds"
  database_port                         = var.database_port
  multi_az                              = var.multi_az
  allocated_storage                     = var.allocated_storage
  storage_encrypted                     = var.storage_encrypted
  engine                                = var.engine
  engine_version                        = var.engine_version
  instance_class                        = var.instance_class
  db_parameter_group                    = var.db_parameter_group
  vpc_id                                = var.vpc_id_db
  security_group_ids                    = var.security_group_ids
  apply_immediately                     = var.apply_immediately
  subnet_ids                            = var.subnet_ids
  db_parameter = [
    {
      name                              = "myisam_sort_buffer_size"
      value                             = "1048576"
      apply_method                      = "immediate"
    },                      
    {                     
      name                              = "sort_buffer_size"
      value                             = "2097152" 
      apply_method                      = "immediate"
    }
  ]

  context = module.this.context
}