#################################################
#                  Database                     #
#################################################

variable "database_port" {
  type        = number
  default     = 1433
  description = "Database port (_e.g._ `3306` for `MySQL`). Used in the DB Security Group to allow access to the DB instance from the provided `security_group_ids`"
}

variable "deletion_protection" {
  type        = bool
  default     = true
  description = "Set to true to enable deletion protection on the RDS instance"
}

variable "multi_az" {
  type        = bool
  default     = false
  description = "Set to true if multi AZ deployment must be supported"
}

variable "storage_encrypted" {
  type        = bool
  default     = false
  description = "(Optional) Specifies whether the DB instance is encrypted. The default is false if not specified"
}

variable "allocated_storage" {
  type        = number
  default     = 1
  description = "The allocated storage in GBs"
}

variable "engine" {
  type        = string
  default     = "sqlserver-se"
  description = "Database engine type"
}

variable "engine_version" {
  type        = string
  default     = "14.0.3465.1"
  description = "Database engine version, depends on engine type"
}

variable "major_engine_version" {
  type        = string
  default     = "14.0"
  description = "Database MAJOR engine version, depends on engine type"
}

variable "instance_class" {
  type        = string
  default     = "db.t3.micro"
  description = "Class of RDS instance"
}

variable "db_parameter_group" {
  type        = string
  default     = null
  description = "Parameter group, depends on DB engine used"
}

variable "apply_immediately" {
  type        = bool
  default     = false
  description = "Specifies whether any database modifications are applied immediately, or during the next maintenance window"
}

variable "subnet_ids" {
  description = "List of subnet IDs for the DB. DB instance will be created in the VPC associated with the DB subnet group provisioned using the subnet IDs. Specify one of `subnet_ids`, `db_subnet_group_name` or `availability_zone`"
  type        = list(string)
  default     = []
}

variable "security_group_ids" {
  type        = list(string)
  default     = []
  description = "The IDs of the security groups from which to allow `ingress` traffic to the DB instance"
}